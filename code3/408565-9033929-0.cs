    // In GenBulkReceipts
    public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        DataSet importDataSet = e.Argument as DataSet;
        AccountsToBeImported =
             new BLLService().Get_AccountsToBeReceipted(importDataSet, worker);
    }
    // In GenBulkReceiptsBLL
    public DataSet Get_AccountsToBeReceipted(DataSet dsImport,
                                             BackgroundWorker worker)
    {
        ...
        worker.ReportProgress(...);
    }
