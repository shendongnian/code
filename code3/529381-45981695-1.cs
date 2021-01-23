    public delegate void delBG(string s);
    class BGimplent
    {
        public event  delBG eveBG;
        private ManualResetEvent mnuReset = new ManualResetEvent(false);
        public ManualResetEvent ManualReset { get; set; }
        public int MyProperty { get; set; }
        
        BackgroundWorker bgWorker = new BackgroundWorker();
        public void DoConfig()
        {
            ManualReset = mnuReset;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();            
        }
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
                
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {   
            Thread.Sleep(5000);
            if (eveBG != null)
                eveBG("Value of MyProperty: " + MyProperty.ToString());
        }
        
    }
}
