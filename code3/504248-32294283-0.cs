    Outlook.Application app = new Outlook.Application();
    Outlook.NameSpace ns = app.GetNamespace("MAPI");
            
    // optional
    //object missing = Type.Missing;
    //ns.Logon(missing, missing, true, false);
                
    // additional email address 
    string recipientName = "myEmail@myDomain";
    
    Outlook.Recipient recip = ns.CreateRecipient(recipientName);
    recip.Resolve();
    
    if (recip.Resolved)
    {
    Outlook.MAPIFolder inboxFolder = ns.GetSharedDefaultFolder(recip, Outlook.OlDefaultFolders.olFolderInbox);
    }
