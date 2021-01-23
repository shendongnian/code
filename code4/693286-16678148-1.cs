    public IEnumerable<TradeUploadInfo> AllocateTrades2(Importer tradeImporter, bool foo)
    {
        foreach( ... )
        {
            TradeUploadInfo bar; // = ...
            // ...
            yield return bar;
        }
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        ProgressClass obj = new ProgressClass();
        Importer tradeImporter = e.Argument as Importer;
        BackgroundWorker worker = sender as BackgroundWorker;
        List<TradeUploadInfo> list = new List<TradeUploadInfo>();
        foreach ( TradeUploadInfo info in obj.AllocateTrades2(tradeImporter, false) )
        {
            list.Add( info );
            // ... progress
        }
        e.Result = list; //Passes the list for processing
    }
