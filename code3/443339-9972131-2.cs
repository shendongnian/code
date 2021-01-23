    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    CrystalReport1 objRpt = new CrystalReport1();
    objRpt.SetDataSource(ds.Tables[1]);
    crystalReportViewer1.ReportSource = objRpt;
    crystalReportViewer1.Refresh(); 
