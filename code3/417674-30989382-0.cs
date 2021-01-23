    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using CrystalDecisions.CrystalReports;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Windows.Forms;
    namespace myapp
    {
	
	public partial class tstfrm1 : Form
	{
		public tstfrm1()
		{
			
			InitializeComponent();
			
			ReportDocument rptDoc = new ReportDocument();
			rptDoc.Load(@"C:\CrystalReport1.rpt");
			CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();
			crystalReportViewer1.ReportSource = rptDoc;
			crystalReportViewer1.Refresh(); 
			this.Controls.Add(crystalReportViewer1);
			crystalReportViewer1.Dock = DockStyle.Fill;
		}
	}
}
