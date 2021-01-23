    using DevExpress.XtraReports.UI;
    using DevExpress.XtraReports.UserDesigner;    
    // ...
    
    private void btnDesign_Click(object sender, EventArgs e)
    {
        var rpt = new Reports.XtraReport1();
        var designer = new ReportDesignTool(rpt);
        designer.ShowRibbonDesignerDialog();
    }
