    public static async Task DeleteFolderContentsAsync(StorageFolder folder,
       StorageDeleteOption option)
    {
       // Try to delete all files
       var files = await folder.GetFilesAsync();
       foreach (var file in files)
       {
          await file.DeleteAsync(option);
       }
       // Iterate through all subfolders
       var subFolders = await folder.GetFoldersAsync();
       foreach (var subFolder in subFolders)
       {
          // Delete the contents
          await DeleteFolderContentAsync(subFolder, option);
 
          // Delete the subfolder
          await subFolder.DeleteAsync(option);
       }
    }
