    //untested
    private void btRunProcessAndRefresh_Click(object sender, EventArgs e)
    { 
        var p = Process.Start(@"\\fileserve\department$\ReportScheduler_v3.exe", "12"); 
        p.Exited = ProcessExited;
        p.EnableRaisingEvents = true;
        //InitializeGridView(); 
    }     
    
    void ProcessExited(object sender, EventArgs e)
    {
        nitializeGridView();    
    }
