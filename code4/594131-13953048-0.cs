    using System;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    // ...
    
    private void button1_Click(object sender, EventArgs e) {
        // Create a report instance, assigned to a Print Tool.
        ReportPrintTool pt = new ReportPrintTool(new XtraReport1());
    
        // Invoke the Print dialog.
        pt.PrintDialog();
    
        // Send the report to the default printer.
        pt.Print();
    
        // Send the report to the specified printer.
        pt.Print("myPrinter");
    }
