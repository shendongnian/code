    public void DoTransaction()
    {
        part1();
        backgroundWorker.ReportProgress(25);
        
        part2();
        backgroundWorker.ReportProgress(50);
        part3();
        backgroundWorker.ReportProgress(75);
        part4();
        backgroundWorker.ReportProgress(100);
    }
