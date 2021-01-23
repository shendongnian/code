    public static void DisplayInbox(ApplicationClass o)
    {
      // Get items in my inbox. 
      NameSpace outlookNS = o.GetNamespace("MAPI");
      MAPIFolder inboxFolder 
        = outlookNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      // Print out some basic info. 
      Console.WriteLine("You have {0} e-mails.", 
        inboxFolder.Items.Count);
      Console.WriteLine();
      foreach(object obj in inboxFolder.Items)
      {
        MailItem item = obj as MailItem;
        if(item != null)
        {
          Console.WriteLine("-> Received: {0}", 
            item.ReceivedTime.ToString());
          Console.WriteLine("-> Sender: {0}", item.SenderName);
          Console.WriteLine("-> Subject: {0}", item.Subject);
          Console.WriteLine();
        }
      }
    }
