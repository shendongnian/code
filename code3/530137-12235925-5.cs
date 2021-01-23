    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
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
                FormClosing += Form1_FormClosing;
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    // Abort Shutdown
                    Process.Start("shutdown.exe", "-a");
                    _isShutdown = true;
                }
                if (!_isRunningUpdate && _isClosing) return;
                // Set isClosing to true
                _isClosing = true;
                if (!_isRunningUpdate)
                {
                    _isRunningUpdate = true;
                    DbUpdate();
                }
                // Cancel current close request
                e.Cancel = true;
                // Optional Hide() --- could display message
                // Hide();
            }
            private void DbUpdate()
            {
                /*Simulate Work - Replace with your work*/
                Thread.Sleep(3000);
                _isRunningUpdate = false;
                if (_isShutdown)
                    Process.Start("shutdown.exe", "-s -t 10");
                if (_isClosing)
                    Close();
            }
        }
    }
