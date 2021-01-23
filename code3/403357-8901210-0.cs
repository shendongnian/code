    public void ShowEmail(string To, string Subject, string Body)
    {
        Outlook.Application myOutlook = new Outlook.Application();
        Outlook.NameSpace myNamespace = myOutlook.GetNamespace("MAPI");
        myNamespace.Logon(null, null, null, null);
        Outlook.MAPIFolder outbox = myNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox);
        Outlook.MailItem mail = (Outlook.MailItem)outbox.Items.Add(Outlook.OlItemType.olMailItem);
    
        mail.Recipients.Add(To);
        mail.Subject = Subject;
        mail.Body = Body;
    
        mail.GetInspector.Activate();
    }
    
    Go ahead and test it, create a button on your form and in the Click event handler:
    
    private void button1_Click(object sender, EventArgs e)
    {
        ShowEmail("youremailOutlookAddress.com", "Hello!", "Hey here's a test Email!");
    }
