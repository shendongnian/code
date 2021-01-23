    class SlowOperation
    {
        BackgroundWorker m_worker;
        void StartPolling()
        {
            m_worker = new BackgroundWorker();
            m_worker.WorkerSupportsCancellation = true;
            m_worker.WorkerReportsProgress = true;
            m_worker.DoWork += m_worker_DoWork;
            m_worker.ProgressChanged += m_worker_ProgressChanged;
        }
        void m_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!m_worker.CancellationPending)
            {
                int returnedPing = 0;
                // Get my data
                m_worker.ReportProgress(0, returnedPing);
                Thread.Sleep(1000);
            }
        }
        void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myForm.Invoke(myForm.UpdateMyPing((int)e.UserState));
        }
    }
