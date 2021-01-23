            Folder rootfolder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot);
            rootfolder.Load();
    
            foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
            {
                // Finds the emails in a certain folder, in this case the Junk Email
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.JunkEmail, new ItemView(10));
    
                // Enter your destination folder name below this:
                if (folder.DisplayName == "Example")
                {
                    // Stores the Folder ID in a variable
                    var fid = folder.Id;
                    Console.WriteLine(fid);
                    foreach (Item item in findResults.Items)
                    {
                        // Load the email, move it to the specified folder
                        item.Load();
                        item.Move(fid);
                    }
    
                }
            }
