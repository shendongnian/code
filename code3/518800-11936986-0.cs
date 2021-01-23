    partial class Form1 { 
        public void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            //e.Argument always contains whatever was sent to the background worker 
            // in RunWorkerAsync. We can simply cast it to its original type.
            DataSet ds = (DataSet)e.Argument;
            var bgw = (BackgroundWorker)sender;
    
            var eh = new ProgressChangedEventHandler((o,a) => bgw.ReportProgress(a.ProgressPercentage));
            createje.ProgressChanged += eh;
            this.createje.ProcessData(this.ds));
            createje.ProgressChanged -= eh; //necessary to stop listening
        }
    
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = CreateJE.max;
            this.progressBar1.Value = e.ProgressPercentage;
        }
    
    }
    partial class CreateJE { 
        public event ProgressChangedEventHandler ProgressChanged; 
        protected virtual void OnProgressChanged(ProgressChangedEventArgs e)
        { 
            var hand = ProgressChanged; 
            if(hand != null) hand(this, e);
        }
    
        public void ProcessData(DataSet ds)
        {
            for(int i = 1; i <= 10; i++)
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
        
                var e = new ProgressChangedEventArgs(i * 10, null);
            }
        }
    
    }
