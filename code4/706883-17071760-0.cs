    private void Page_Load(object sender, System.EventArgs e)
    {
        NMBS.ViewModels.ViewModelReport Report = (Session["CurrentReport"] as NMBS.ViewModels.ViewModelReport);
    ReportViewer.ProcessingMode = ProcessingMode.Local;
    ReportViewer.PageCountMode = PageCountMode.Actual;
    // Set report specifics.
    ReportViewer.LocalReport.DisplayName = Report.Name;
    ReportViewer.LocalReport.LoadReportDefinition(new System.IO.StringReader(Report.Definition));
    foreach (ReportParameter Param in Report.Parameters)
    {
        ReportViewer.LocalReport.SetParameters(Param);
    }
    foreach (ReportDataSource Rds in Report.Data)
    {
        //Load Report Data.
        ReportViewer.LocalReport.DataSources.Add(Rds);
    }
    ReportViewer.CurrentPage = Report.CurrentPage;
    ReportViewer.Width = Report.Width;
    
    // Refresh the reports.
    ReportViewer.LocalReport.Refresh();
    }
