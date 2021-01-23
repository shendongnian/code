    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace VirtualKeyboard
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Open_Click(object sender, EventArgs e)
            {
                Process.Start(@"C:\Program Files\Common Files\microsoft shared\ink\tabtip.exe");
            }
    
            private void Close_Click(object sender, EventArgs e)
            {
                Process[] processlist = Process.GetProcesses();
    
                foreach(Process process in processlist)
                {
                    if (process.ProcessName == "TabTip")
                    {
                        process.Kill();
                        break;
                    }
                }
            }
    
        }
    }
