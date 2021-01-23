    public void RunReport()
    {
        ModifyExcelSecuritySettings();
    
        // Launch Excel on the server
        Excel = new Application
        {
            DisplayAlerts = false,
            ScreenUpdating = false,
            Visible = false
        };
    
    .....
