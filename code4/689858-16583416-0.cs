    Outlook.Explorer curExplorer = OutlookApplication.ActiveExplorer();
    Outlook.NameSpace curNameSpace = OutlookApplication.GetNamespace("MAPI");
    Outlook.MAPIFolder curFolder = curExplorer.CurrentFolder;
    if (curExplorer.Selection != null && curExplorer.Selection.Count > 0)
    {
        // get mails
        _lstMailItems = new List<Outlook.MailItem>();
        try
        {
            foreach (Outlook.MailItem curMailItem in curExplorer.Selection)
            {
                // modification on mail items in plugin are repercuted in Outlook
                _lstMailItems.Add(curMailItem);
            }
        }
        catch (COMException exc)
        {
            // log, selected item is not an email.
        }
    }
