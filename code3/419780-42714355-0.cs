    Maintain a list which will store the sender's name then check a condition that the recent mail's sender contains in the list if yes than Download.
    
    
    private void ThisApplication_NewMail()
    {
        const string destinationDirectory = @"C:\TestFileSave";
        List<string> senderList = new List<string>();
        if (!Directory.Exists(destinationDirectory))
        {
            Directory.CreateDirectory(destinationDirectory);
        }
    
        MAPIFolder sentMail = Application.ActiveExplorer().Session.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
        Items sentMailItems = sentMail.Items;
        try
        {
            foreach (object collectionItem in sentMailItems)
            {
                MailItem newEmail = collectionItem as MailItem;
                senderEmailAdd = newEmail.SenderEmailAddress;
                if (newEmail == null) continue;
    
                if (newEmail.Attachments.Count > 0 && senderList.Contains(senderEmailAdd))
                {
                    for (int i = 1; i <= newEmail.Attachments.Count; i++)
                    {
                        string filePath = Path.Combine(destinationDirectory, newEmail.Attachments[i].FileName);
                        newEmail.Attachments[i].SaveAsFile(filePath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
