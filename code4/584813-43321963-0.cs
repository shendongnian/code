    /// <summary>
    /// Moves the email to the specified folder.
    /// </summary>
    /// <param name="mail">Email message to move.</param>
    /// <param name="folderName">Display name of the folder.</param>
    public void MoveToFolder(EmailMessage mail, string folderName)
    {
        Folder rootfolder = Folder.Bind(_exchangeService, WellKnownFolderName.MsgFolderRoot);
        rootfolder.Load();
        Folder foundFolder = rootfolder.FindFolders(new FolderView(100)).FirstOrDefault(x => x.DisplayName == folderName);
        if (foundFolder == default(Folder))
        {
            throw new DirectoryNotFoundException(string.Format("Could not find folder {0}.", folderName));
        }
    
        mail.Move(foundFolder.Id);
    }
