    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new ReportDocument();
    rd.Load("AgedItems_3.rpt");
    try
    {
    string datetext = RunDate.ToString("dd/MM/yyyy HH:mm");
    rd.DataDefinition.FormulaFields["ProcessDate"].Text = "#"+datetext+"#";
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
                
                
    crystalReportViewer2.ReportSource = rd;
