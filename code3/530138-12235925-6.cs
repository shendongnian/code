    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    using Timer = System.Windows.Forms.Timer;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private bool _isClosing;
            private bool _isRunningUpdate;
            private bool _isShutdown;
            private Timer timer;
            public Form1()
            {
                InitializeComponent();
                FormClosing += Form1_FormClosing;
                timer = new Timer();
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
                    timer.Tick += DbUpdate;
                    timer.Interval = 500;
                    timer.Enabled = true; 
                    timer.Start();
                }
                // Cancel current close request
                e.Cancel = true;
                // Optional Hide() --- could display message
                // Hide();
            }
            private void DbUpdate(object sender, EventArgs e)
            {
                timer.Stop();
                Thread.Sleep(3000);
                _isRunningUpdate = false;
                if (_isShutdown)
                    Process.Start("shutdown.exe", "-s -t 10");
                if (_isClosing)
                    Close();
            }
        }
    }
