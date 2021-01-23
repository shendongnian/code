        public void getEmailCount(Action<int> callback)
        {
            int unreadCount = 0;
            FolderView viewFolders = new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep, PropertySet = new PropertySet(BasePropertySet.IdOnly) };
            ItemView viewEmails = new ItemView(int.MaxValue) { PropertySet = new PropertySet(BasePropertySet.IdOnly) };
            SearchFilter unreadFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            SearchFilter folderFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "AllItems"));
            FindFoldersResults inboxFolders = service.FindFolders(WellKnownFolderName.Root, folderFilter, viewFolders);
            if (inboxFolders.Count() == 0)//if we don't have AllItems folder
            {
                //search all items in Inbox and subfolders
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, unreadFilter, viewEmails);
                unreadCount += findResults.Count();
                inboxFolders = service.FindFolders(WellKnownFolderName.Inbox, viewFolders);
                foreach (Folder folder in inboxFolders.Folders)
                {
                    findResults = service.FindItems(folder.Id, unreadFilter, viewEmails);
                    unreadCount += findResults.Count();
                }
            }
            else //AllItems is avilable
            {
                foreach (Folder folder in inboxFolders.Folders)
                {
                    FindItemsResults<Item> findResults = service.FindItems(folder.Id, unreadFilter, viewEmails);
                    unreadCount += findResults.Count();
                }
            }
            callback(unreadCount);
        }
