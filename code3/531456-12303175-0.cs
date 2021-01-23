    private Outlook.Folder inbox;
    private List<Outlook.Items> folderItems = new List<Outlook.Items>();
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        inbox = this.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox) as Outlook.Folder;
        for (int i = 1; i < inbox.Folders.Count+1; i++)
        {
            folderItems.Add((inbox.Folders[i] as Outlook.Folder).Items);
            folderItems[i - 1].ItemAdd += (item) =>
            {
                Outlook.MailItem msg = item as Outlook.MailItem;
                Outlook.Folder target = msg.Parent as Outlook.Folder;
                string folderName = target.Name;
            };
        }
    }
