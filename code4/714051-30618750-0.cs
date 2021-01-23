        using System;
    using System.Windows.Forms;
    using DevExpress.XtraReports.UI;
    // ... 
    
    private void Form1_Load(object sender, EventArgs e) {
        XtraReport1 objreport= new XtraReport1();
        ReportDesignTool objReportdesigner = new ReportDesignTool(objreport);
    
        // Invoke the standard End-User Designer form. 
        objReportdesigner`enter code here`.ShowDesigner();
    
        // Invoke the standard End-User Designer form modally. 
        objReportdesigner.ShowDesignerDialog();
    
        // Invoke the Ribbon End-User Designer form. 
        objReportdesigner.ShowRibbonDesigner();
    
        // Invoke the Ribbon End-User Designer form modally. 
        objReportdesigner.ShowRibbonDesignerDialog();
    }
