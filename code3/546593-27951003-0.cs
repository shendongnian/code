    public List<Common.MailFolder> ListFolders()
        {
            try
            {
                List<Common.MailFolder> myFolders = new List<Common.MailFolder>();
                Common.MailFolder myFolder;
                List<ExchangeFolder> myExchangeFolders = new List<ExchangeFolder>();
                FolderView myView = new FolderView(10);
                myView.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties, FolderSchema.DisplayName, FolderSchema.Id);
                myView.Traversal = FolderTraversal.Shallow;
                FindFoldersResults myResults = myService.FindFolders(WellKnownFolderName.MsgFolderRoot, myView);
                foreach (Folder folder in myResults)
                {
                    myFolder = new Common.ICE.MailFolder();
                    myFolder.NewMessageCount = Folder.Bind(myService, folder.Id).UnreadCount;
                    myFolder.FolderId = folder.Id.ToString();
                    myFolder.FolderName = folder.DisplayName;
                    myFolders.Add(myFolder);
                }
                return myFolders;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Exchange Helper - List Folders", ex, Utility.GetUserId());
                return null;
            }
        }
