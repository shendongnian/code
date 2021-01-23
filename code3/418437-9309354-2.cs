    var ns = application.GetNamespace("MAPI");
    MAPIFolder inbox = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
    for (int i = 1; i <= inbox.Items.Count; i++)
    {
        var item = (MailItem) inbox.Items[i];
        Console.WriteLine("Subject: {0}", item.Subject);
        //...
    }
