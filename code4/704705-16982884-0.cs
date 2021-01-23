      class BackgroundClass
        {
        public event EventHandler CancelWorker;
        BackgroundWorker worker = new BackgroundWorker();
        BackgroundClass()
        {
            CancelWorker += new EventHandler(BackgroundClass_CancelWorker);
        }
        void BackgroundClass_CancelWorker(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }
        void RunBackgroundWorker()
        {   
            worker.DoWork += (sender, args) =>
            {
                VeryLongTimeComputingFunction();
            };
        }
        void VeryLongTimeComputingFunction()
        {
            if (CancelWorker != null)
            {
                CancelWorker(this, new EventArgs());
            }
        }
    }
