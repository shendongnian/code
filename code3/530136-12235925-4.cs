    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    using System.Diagnostics;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private bool _isClosing;
            private bool _isRunningUpdate;
            private bool _isShutdown;
            public Form1()
            {
                InitializeComponent();
                FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if(e.CloseReason==CloseReason.WindowsShutDown) {
                    // Abort Shutdown
                    Process.Start("shutdown.exe", "-a");
                    _isShutdown = true;
                }
                if (!_isRunningUpdate && _isClosing) return;
                // Set isClosing to true
                _isClosing = true;
                if (!_isRunningUpdate)
                {
                    // Perform the database task
                    BackgroundWorker updateDb = new BackgroundWorker
                                                    {WorkerReportsProgress = false, WorkerSupportsCancellation = false};
                    updateDb.DoWork += DbUpdate;
                    updateDb.RunWorkerCompleted += DbUpdateCompleted;
                    updateDb.RunWorkerAsync();
                    _isRunningUpdate = true;
                }
                // Cancel current close request
                e.Cancel = true;
                
                // Optional Hide() --- could display message
                // Hide();
            }
            void DbUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                _isRunningUpdate = false;
                if(_isShutdown)
                    Process.Start("shutdown.exe", "-s -t 10");
                if(_isClosing)
                    Close();
            }
            private void DbUpdate(object sender, DoWorkEventArgs e)
            {
                Thread.Sleep(3000);
            }
        }
    }
