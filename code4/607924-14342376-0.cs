        Outlook.Application outlook = new Outlook.ApplicationClass();
        Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
        object _missing = Type.Missing;
        ns.Logon(_missing, _missing, false, true);
        Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
       
        int unread = inbox.UnReadItemCount;
        foreach (Outlook.MailItem mail in inbox.Items)
        {
            string s = mail.Subject;
        } 
