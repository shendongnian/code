    BackgroundWorker bw;
    
    public void StartBackgroundLoop() {
        bw = new BackgroundWorker();
        bw.WorkerSupportsCancellation = true;
        bw.WorkerReportsProgress = true;
    
        bw.DoWork += (sender, e) => {
            // this will happen in a background thread
            while (!bw.CancellationPending) {
                data = Sample_USB_Device();
                bw.ReportProgress(0, data);
            }
        }
    
        // this event is triggered *in the UI thread* by bw.ReportProgress
        bw.ProgressChanged += (sender, e) => {
            Data data = (Data)e.UserState;  // this is the object passed to ReportProgress
            Present_Data_To_Screen(data);
        }
    
        bw.RunWorkerAsync(); // starts the background worker
    }
    public void StartBackgroundLoop() {
        bw.CancelAsync();     // sets bw.CancellationPending to true
    }
