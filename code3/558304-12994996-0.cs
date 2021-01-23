    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	 ConnectClass conObject= new ConnectClass();
         backgroundWorker.ReportProgress(30, "Connecting ...");
         conObject.Connect();
         backgroundWorker.ReportProgress(30, "Connected."+"\n Executing query");
         conObject.Execute();
         backgroundWorker.ReportProgress(40, "Execution completed.");
    }
