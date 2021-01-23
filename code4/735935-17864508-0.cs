    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Management;
    
    namespace HaardDiskInfoCSharp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
    
                foreach (ManagementObject moProcessor in mosProcessor.Get())
                {
                    
                    if(moProcessor["maxclockspeed"]!=null)
                        lblPMCSpeed.Text = moProcessor["maxclockspeed"].ToString();
                    if(moProcessor["datawidth"]!=null)
                        lblPDataWidth.Text = moProcessor["datawidth"].ToString();
                    if(moProcessor["name"]!=null)
                        lblPName.Text=moProcessor["name"].ToString();
                    if(moProcessor["manufacturer"]!=null)
                        lblPManufacture.Text = moProcessor["manufacturer"].ToString();
    
                }
            }
        }
    }
