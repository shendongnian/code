    ImapX.Collections.FolderCollection folders = imapclient.Folders;
    ImapX.Collections.MessageCollection messages = imapclient.Folders["INBOX"].Search("UNSEEN", true); 
    foreach (var mess in messages)
    {
        mess.AddFlag(ImapX.Flags.MessageFlags.Seen); 
    }
