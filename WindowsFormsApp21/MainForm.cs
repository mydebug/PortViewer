using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        List<string> protList=new List<string>();
        private void ScanButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();
            IPEndPoint[] udpEndPoints = properties.GetActiveUdpListeners();
            protList=tcpEndPoints.ToList().Select(s => s.ToString()).ToList();
            protList.AddRange(udpEndPoints.Select(s=>s.ToString()));
            listBox1.DataSource = protList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                listBox1.DataSource = protList;
                return;
            }
            listBox1.DataSource = protList.Where(w => w.Contains(textBox1.Text)).ToList();
        }
    }
}
