     public async void deletefile()
            {
                StorageFolder sourceFolder =  ApplicationData.Current.TemporaryFolder;
               // sourceFolder = await sourceFolder.GetFolderAsync("Test");
               // await sourceFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
                
    
              // var files = await sourceFolder.GetFilesAsync();
    
               IReadOnlyList<StorageFile> folderList = await sourceFolder.GetFilesAsync();
                if (folderList.Count > 0)
                {
                    foreach (StorageFile f1 in folderList)
                    {
    
                        await f1.DeleteAsync(StorageDeleteOption.PermanentDelete);
                    }
                }
                
               //StorageFile retfile = await ApplicationData.Current.TemporaryFolder.GetFileAsync("MysoundFile.mp3");
               // if (retfile != null)
               // {
               //     await retfile.DeleteAsync(StorageDeleteOption.PermanentDelete);
               // }
    
    
            }
