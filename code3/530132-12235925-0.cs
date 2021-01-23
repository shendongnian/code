    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private bool _isClosing;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (_isClosing) return;
                // Set isClosing to true
                _isClosing = true;
                // Perform the database task
                BackgroundWorker updateDb = new BackgroundWorker { WorkerReportsProgress = false, WorkerSupportsCancellation = false };
                updateDb.DoWork += DbUpdate;
                updateDb.RunWorkerCompleted += DbUpdateCompleted;
                updateDb.RunWorkerAsync();
            
                // Cancel current close request
                e.Cancel = true;
                // Hide form here ?
                Hide();
            }
            void DbUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if(_isClosing)
                    Close();
            }
            private void DbUpdate(object sender, DoWorkEventArgs e)
            {
                /* Simulate Work */
                Thread.Sleep(5000);
            }
        }
    }
