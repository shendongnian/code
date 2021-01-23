    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    using System.Management;
    
    namespace Hard_Disk_Interface
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnCheck_Click(object sender, EventArgs e)
            {
                WqlObjectQuery q = new WqlObjectQuery("SELECT * FROM Win32_IDEController");
                ManagementObjectSearcher res = new ManagementObjectSearcher(q);
                lblHDDChanels.Text = string.Empty;
                foreach (ManagementObject o in res.Get())
                {
                    string Caption = o["Caption"].ToString();
    
                    lblHDDChanels.Text += Caption + "\n\n";
                    if (Caption.Contains("Serial"))
                    {
                        lblInterface.Text = "S-ATA";
                    }
                }
            }
        }
    }
