    public partial class Form1 : Form
    {
        private ThreadOwner _threadOwner;
        public Form1()
        {
            InitializeComponent();
            var _threadOwner = new ThreadOwner();
            _threadOwner.StartAThread(this,progressBar1.Minimum,progressBar1.Maximum);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            _threadOwner.Exit();
            base.OnClosing(e);
        }
        internal void SetProgress(int progress)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(
                    new Action<Form1>(
                        (sender) => { 
                            SetProgress(progress); 
                        }
                        ),new[] { this }
                        );
            }
            else
                progressBar1.Value = progress;
        }
    }
