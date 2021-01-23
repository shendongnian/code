    int appVersion = Convert.ToInt32(Globals.ThisAddIn.Application.Version.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0]);
    if (appVersion >= 14 )            
    {
    	ThisRibbonCollection ribb = Globals.Ribbons;
        ribb.[Your Ribbon].ApplicationGroup.RibbonUI.ActivateTab("tab");                
    }
    else if(appVersion == 12)  // Specific to Office 2007 only.
    {
                    SendKeys.Send("%TAB%"); // use sendwait if you running it in thread.
    }
    
