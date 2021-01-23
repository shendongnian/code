    using System;
    using System.ComponentModel;
    namespace WindowsTest
    {
    public class Connect
    {
        BackgroundWorker bw;
        public Connect()
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.DoWork +=new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }
        public delegate void ProgressChangedHandler(Object sender, ProgressChangedEventArgs e);
        public event ProgressChangedEventHandler ProgressChanged;
        protected void RaiseProgressChangedEvent(ProgressChangedEventArgs e)
        {
            if (ProgressChanged == null)
            {
                return;
            }
            ProgressChanged(this, e);
        }
        public delegate void WorkCompleteEventHandler(Object sender, RunWorkerCompletedEventArgs e);
        public event WorkCompleteEventHandler WorkComplete;
        protected void RaiseWorkCompleteEvent(RunWorkerCompletedEventArgs e)
        {
            if (WorkComplete == null)
            {
                return;
            }
            WorkComplete(this, e);
        }
        public void Cancel()
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();            
            }
        }
        public void BeginLongRunningProcess()
        {
            bw.RunWorkerAsync();
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RaiseWorkCompleteEvent(e);
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RaiseProgressChangedEvent(e);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ConnectToServer())
            {
                bw.ReportProgress(0, "Connected to server");
                e.Result = LongRunningProcess();
                if (e.Result.ToString() == "Cancelled")
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                //Connection failed
                e.Cancel = true;    
            }
        }
        private bool ConnectToServer()
        { 
            //Attempt connection
            return true;
        }
        private string LongRunningProcess()
        {
            int recordCount = 250;
            for (int i = 0; i <= recordCount; i++)
            {
                if (bw.CancellationPending)
                {
                    return "Cancelled";
                }
                double progress = ((double)i / (double)recordCount) * 100;
                bw.ReportProgress((int)progress , "Running Process");
                System.Threading.Thread.Sleep(25);
            }
            return "The result is 2";
        }
    }
    }
