    protected void Page_Load(object sender, EventArgs e)
    {       
        this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MainLevelDs", SqlDs_ReportsMain));
        this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
    }
    void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        e.DataSources.Add(new ReportDataSource("MidLevelDs", SqlDs_ReportsMid));
    }
    
