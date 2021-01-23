    ImapX.FolderCollection folders = imapclient.Folders;
    ImapX.MessageCollection messages = imapclient.Folders["INBOX"].Search("UNSEEN", true); 
    foreach (var mess in messages)
    {
        mess.AddFlag(ImapFlags.SEEN); 
    }
