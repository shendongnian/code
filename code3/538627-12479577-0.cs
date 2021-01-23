    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace RemoteMonitor
    {
        public partial class RemoteMonitor : Form
        {
            Thread cThread;
            Server cServer;
    
            public RemoteMonitor()
            {
                InitializeComponent();   
            }
    
            private void RemoteMonitor_Load(object sender, EventArgs e)
            {
                WriteLog("Programm started!");
                
                cServer = new Server();
                cThread = new Thread(() => cServer.StartServer(this));
                cThread.Start();
            }
    
            public void WriteLog(string sText)
            {
                if (InvokeRequired)
                {
                    Action action = () => lsbLogger.Items.Add(sText);
                    lsbLogger.Invoke(action);
                }
                else
                {
                    lsbLogger.Items.Add(sText);
                }
            }
        }
    }
