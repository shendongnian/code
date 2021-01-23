	public static int GetTotalUnreadCount(ExchangeService ewsConnector)
	{
		int pagedView = 1000;
		FolderView fv = new FolderView(pagedView) { Traversal = Microsoft.Exchange.WebServices.Data.FolderTraversal.Deep };
		fv.PropertySet = new PropertySet(BasePropertySet.IdOnly, FolderSchema.UnreadCount, FolderSchema.DisplayName);
		FindFoldersResults findResults = ewsConnector.FindFolders(WellKnownFolderName.MsgFolderRoot, fv);
		int totalUnreadCount = 0;
		foreach (Folder f in findResults.Folders)
		{
			try
			{
				totalUnreadCount += f.UnreadCount;
				Console.WriteLine("Folder [" + f.DisplayName + "] has [" + f.UnreadCount.ToString() + "] unread items.");
			}
			catch(Exception ex)
			{
				Console.WriteLine("Folder [" + f.DisplayName + "] does not have the unread property.");
			}
		}
		Console.WriteLine("Mailbox has [" + totalUnreadCount.ToString() + "] unread items.");
		
        return totalUnreadCount;
	}
