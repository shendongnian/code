    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        var app = Globals.ThisAddIn.Application;
        app.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(Application_WorkbookActivate);
        app.WorkbookDeactivate += new Excel.AppEvents_WorkbookDeactivateEventHandler(Application_WorkbookDeactivate);
    }
    
    private Guid _GetIdentity(Excel.Workbook Wb)
    {
        try
        {
            // check for GUID
            Microsoft.Office.Core.DocumentProperties properties = Wb.CustomDocumentProperties;
            Microsoft.Office.Core.DocumentProperty version = properties["_CustomIdentifier"];
    
            // parse the version for decide what features to activate
            Guid guidVersion;
            return Guid.TryParse(Convert.ToString(version.Value), out guidVersion) ? guidVersion : Guid.Empty;
        }
        catch
        {
            return Guid.Empty;
        }
    }
    
    void Application_WorkbookDeactivate(Excel.Workbook Wb)
    {
       Globals.Ribbons.MyRibbon.btnButtonName.Visible = false;
    }
    
    void Application_WorkbookActivate(Excel.Workbook Wb)
    {
        if(_GetIdentity(Wb) == {PRE-DEFINED-GUID})
        {
            Globals.Ribbons.MyRibbon.btnButtonName.Visible = true;
        }
    }
