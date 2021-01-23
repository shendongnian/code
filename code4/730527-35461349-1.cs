    public void PrintSales(object sender, RenderingCompleteEventArgs e)
    {
        try
        {
            reportViewerSales.PageSetupDailog();
            reportViewerSales.PrintDialog();
            reportViewerSales.Clear();
            reportViewerSales.LocalReport.ReleaseSandboxAppDomain();
        }
        catch (Exception ex)
        {
        }
    }
