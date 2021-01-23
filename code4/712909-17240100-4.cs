    public string GetCustomUI(string ribbonID)
    {
        switch (ribbonID)
        {
            case "Microsoft.Outlook.Appointment" : 
                return GetResourceText("OutlookRibbonApp.IPM.Appointment.Ribbon.xml");
            case "Microsoft.Outlook.Mail.Compose" : 
                return GetResourceText("OutlookRibbonApp.IPM.Note.Ribbon.xml");
            default:
                return "";
        }
    }
