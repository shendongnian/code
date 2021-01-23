    class MyWorkerClass
    {
        volatile bool m_bPaused  = false;
        // Public property to control worker execution
        public bool Paused 
        {
            get { return m_bPaused; }
            set { m_bPaused = value; }
        }
    
        long ThreadFunc (BackgroundWorker worker, DoWorkEventArgs e)
        {
            ...
            // While Paused property set to true
            while (m_bPaused)
            {
                // Pause execution for some time
                System.Threading.Thread.Sleep (100);      
            }
        }
    }
