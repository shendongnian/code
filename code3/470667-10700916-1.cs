    private void Rarbtn_Click(object sender, EventArgs e)
    {
        GetReps();
    
        //Run worker
        if (!CreateRarBW.IsBusy)
        {
            // This should be done once, maybe in the contructor. Bind to new event.
            xXMLandRar.ReportProgress += new EventHandler<XMLandRar.ProgressArgs>(xXMLandRar_ReportProgress);
    
            CreateRarBW.RunWorkerAsync();
        }
    }
    
    protected void xXMLandRar_ReportProgress(object sender, XMLandRar.ProgressArgs e)
    {
        // Call the UI backgroundworker
        CreateRarBW.ReportProgress(e.Percentage, e.Message);
    }
    public class XMLandRar
    {
        // Event handler to bind to for reporting progress
        public EventHandler<ProgressArgs> ReportProgress;
    
        // Eventargs to contain information to send to the subscriber
        public class ProgressArgs : EventArgs
        {
            public int Percentage { get; set; }
            public string Message { get; set; }
        }
    
        public void RarFiles(List repSelected)
        {
            int step = 100 / repSelected.Count();
            int i = 0;
            //Iterate through list and run rar for each
            foreach (string rep in repSelected)
            {
                // Report progress if somebody is listening (subscribed)
                if (ReportProgress != null)
                {
                    ReportProgress(this, new ProgressArgs { Percentage = i, Message = "Raring files for " + rep });
                }
    
                DirectoryExists(rep);
                ProcessRunner(rep);
                i += step;
    
                // Report progress if somebody is listening (subscribed)
                if (ReportProgress != null)
                {
                    ReportProgress(this, new ProgressArgs { Percentage = i, Message = "Raring files for " + rep });
                }
            }
        }
    }
