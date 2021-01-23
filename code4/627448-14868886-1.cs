    // Create Application class and get namespace
    Outlook.Application outlook = new Outlook.ApplicationClass();
    Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
    
        object _missing = Type.Missing;
        ns.Logon(_missing, _missing, false, true);
        
        // Get Inbox information in objec of type MAPIFolder
        Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        
        // Unread emails
        int unread = inbox.UnReadItemCount;
        
        // Display the subject of emails in the Inbox folder
        foreach (Outlook.MailItem mail in inbox.Items)
        {
            Console.WriteLine(Wmail.Subject);
        }
