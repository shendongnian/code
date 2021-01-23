    class MyClass
    {    
        private BackgroundWorker worker;
        public MyClass()
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            Timer timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!worker.IsBusy)
                worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //whatever You want the background thread to do...
        }
    }
