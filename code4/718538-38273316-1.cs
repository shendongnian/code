    private void PrintToPrinter()
        {
            PrintReport(System.Windows.Forms.Application.StartupPath + "\\CrystalReport1.rpt",
                "Send To OneNote 2010");
        }
    private void PrintReport(string reportPath, string PrinterName)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc =
                                new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rptDoc.Load(reportPath);
 
            CrystalDecisions.Shared.PageMargins objPageMargins;
            objPageMargins = rptDoc.PrintOptions.PageMargins;
            objPageMargins.bottomMargin = 100;
            objPageMargins.leftMargin = 100;
            objPageMargins.rightMargin = 100;
            objPageMargins.topMargin = 100;
            rptDoc.PrintOptions.ApplyPageMargins(objPageMargins);
            rptDoc.PrintOptions.PrinterName = PrinterName;
            rptDoc.PrintToPrinter(1, false, 0, 0);
        }
