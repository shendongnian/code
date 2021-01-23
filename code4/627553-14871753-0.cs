    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        t1.changevalue(1000, sender as BackgroundWorker);
    }
    class testClass
    {
        private int val;
        public int changevalue(int i, BackgroundWorker bw)
        {
            for (int j = 0; j < 1000; j++)
            {
                val += i + j;
                bw.ReportProgress(i);
                //from here i need to preport the backgroundworker progress
                //eg; backgroundworker1.reportProgress(j);
            }
            return val;
        }
    } 
