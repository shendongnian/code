    using System;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    // ... 
    
    private void Form1_Load(object sender, EventArgs e) {
        XtraReport1 report = new XtraReport1();
        ReportDesignTool dt = new ReportDesignTool(report);
    
        // Invoke the standard End-User Designer form. 
        dt.ShowDesigner();
    
        // Invoke the standard End-User Designer form modally. 
        dt.ShowDesignerDialog();
    
        // Invoke the Ribbon End-User Designer form. 
        dt.ShowRibbonDesigner();
    
        // Invoke the Ribbon End-User Designer form modally. 
        dt.ShowRibbonDesignerDialog();
    }
