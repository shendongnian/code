    Outlook.Folder sentItems = ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail) as Outlook.Folder;
    sentItems.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(sentItems_ItemAdd);
    // ...
    void sentItems_ItemAdd(object Item)
    {
      var msg = Item as Outlook.MailItem;
      msg.SaveAs(yourPath, Outlook.OlSaveAsType.olMSG);
    }
