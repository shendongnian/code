    private void ThisApplication_NewMail()
    {
        const string destinationDirectory = @"C:\TestFileSave";
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
                if (newEmail == null) continue;
                if (newEmail.Attachments.Count > 0)
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
