            OutLook.Application oApp = new OutLook.Application();
            OutLook.NameSpace oNS = (OutLook.NameSpace)oApp.GetNamespace("MAPI");
            oNS.Logon(Missing.Value, Missing.Value, false, true);
            foreach (OutLook.MAPIFolder folder in oNS.Folders)
            {
                string folderName = folder.Name;
                GetFolders(folder);
            }
 
       public void GetFolders(MAPIFolder folder)
        {
            if (folder.Folders.Count == 0)
            {
                string path = folder.FullFolderPath;
                if (foldersTocheck.Contains(path))
                { 
                    //GET EMAILS.....
                    foreach (OutLook.MailItem item in folder.Items)
                    {
                        Console.WriteLine(item.SenderEmailAddress + " " + item.Subject + "\n" + item.Body);
                       
                      
                    }
                }
            }
            else
            {
                foreach (MAPIFolder subFolder in folder.Folders)
                {
                    GetFolders(subFolder);
                }
            }
        }
