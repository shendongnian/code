    // Define this elsewhere in your class
    static AutoResetEvent reset = new AutoResetEvent(false);
    
    ids.ForEach(g => 
    {
    	var details = items.Where(e => e.guid == guid);
    
    	var ds = new ReportDataSource("Form", details);
    	ReportViewer.LocalReport.DataSources.Clear();
    	ReportViewer.LocalReport.DataSources.Add(ds);
        // This assumes RenderingComplete takes 2 arguments, and you aren't going to need either of them.
        ReportViewer.RenderingComplete += (_,__) =>
        {
            reset.Set(); // This happens after the code below, and this tells the "WaitOne" lock that it can continue on with the rest of the code.
        }
        // Begin the async refresh
    	ReportViewer.RefreshReport();
        reset.WaitOne(); // This call will block until "reset.Set()" is called.
        reset.Reset(); // This resets the state of the AutoResetEvent for the next loop iteration.
    });
