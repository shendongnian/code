    foreach (MAPIFolder folder in olNS.Folders)
    {
        GetFolders(folder);
    }
        
    public void GetFolders(MAPIFolder folder)
    {
        if (folder.Folders.Count == 0)
        {
             Console.WriteLine(folder.FullFolderPath);
        }
        else
        {
             foreach (MAPIFolder subFolder in folder.Folders)
             {
                  GetFolders(subFolder);
             }
        }
    }
