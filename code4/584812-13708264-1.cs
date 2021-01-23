    Folder rootfolder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot);
    rootfolder.Load();
    foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
    {
        // Finds the emails in a certain folder, in this case the Junk Email
        FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.JunkEmail, new ItemView(10));
        // This IF limits what folder the program will seek
        if (folder.DisplayName == "Example")
        {
            // Trust me, the ID is a pain if you want to manually copy and paste it. This stores it in a variable
            var fid = folder.Id;
            Console.WriteLine(fid);
            foreach (Item item in findResults.Items)
            {
                // Load the email, move the email into the id.  Note that MOVE needs a valid ID, which is why storing the ID in a variable works easily.
                item.Load();
                item.Move(fid);
            }
        }
    }
