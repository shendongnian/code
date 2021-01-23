    private static void CreateFolder(SPWeb web, SPList spList, SPListItem currentItem, string folderName)
    {
        if (currentItem.FileSystemObjectType != SPFileSystemObjectType.Folder)
        {
            string itemUrl = web.Url + "/" + currentItem.Url.Substring(0, currentItem.Url.LastIndexOf('/'));
    
            var folder = spList.Items.Add(itemUrl, SPFileSystemObjectType.Folder, folderName);
            string folderUrl = itemUrl + "/" + folder.Name;
    
            if (!FolderExists(folderUrl, web))
            {
                try
                {
                    folder.Update();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
    
    
    public static bool FolderExists(string url, SPWeb web)
    {
        if (url.Equals(string.Empty))
        {
            return false;
        }
    
        try
        {
            return web.GetFolder(url).Exists;
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
