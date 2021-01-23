    class CreateJE
    {
        public Action<int> ReportProgressDelegate{get;set;}
        public void ProcessData(DataSet ds)
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                ReportProgress(i*10);
            }
        }
        private void ReportProgress(int percent)
        {
            if(ReportProgressDelegate != null)
                ReportProgressDelegate(percent);
        }
    }
