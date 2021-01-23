    public static Folder GetPathFolder(ExchangeService service, FindFoldersResults results,
                                       string lookupPath, string currentPath)
    {
        foreach (Folder folder in results)
        {
            string path = currentPath + @"\" + folder.DisplayName;
            if (folder.DisplayName == "Calendar")
            {
                continue;
            }
            
            Console.WriteLine(path);
            
            FolderView view = new FolderView(50);
            SearchFilter filter = new SearchFilter.IsEqualTo(FolderSchema.Id, folder.Id);
            FindFoldersResults folderResults = service.FindFolders(folder.Id, view);
            Folder result = GetPathFolder(service, folderResults, lookupPath, path);
            if (result != null)
            {
                return result;
            }
            
            string[] pathSplitForward = path.Split(new[] {  "/" }, StringSplitOptions.RemoveEmptyEntries);
            string[] pathSplitBack    = path.Split(new[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            string[] lookupPathSplitForward = lookupPath.Split(new[] {  "/" }, StringSplitOptions.RemoveEmptyEntries);
            string[] lookupPathSplitBack    = lookupPath.Split(new[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            
            if (ArraysEqual(pathSplitForward, lookupPathSplitForward) || 
                ArraysEqual(pathSplitBack,    lookupPathSplitBack) || 
                ArraysEqual(pathSplitForward, lookupPathSplitBack) || 
                ArraysEqual(pathSplitBack,    lookupPathSplitForward))
            {
                return folder;
            }
        }
        return null;
    }
