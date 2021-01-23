    class yourClass : Form
    {
        private bool isDisposed = false;
        private CancellationTokenSource cts;
        private bool stopTaskSignal = false;
        public yourClass()
        {
            InitializeComponent();
            this.FormClosing += (s, a) =>
            {
                cts.Cancel();
                isDisposed = true;
                if (!stopTaskSignal)
                    a.Cancel = true;
            };
        }
    
        private void yourClass_Load(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
    
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            token.ThrowIfCancellationRequested();
                        }
    
                        if (this.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { methodToInvoke(); });
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    this.Invoke((MethodInvoker)delegate { stopTaskSignalAndDispose(); });
                }
            }, token);
        }
    
        public void stopTaskSignalAndDispose()
        {
            stopTaskSignal = true;
            this.Dispose();
        }
    
        public void methodToInvoke()
        {
            if (isDisposed) return;
            label_in_form.Text = "text";
        }
    }
