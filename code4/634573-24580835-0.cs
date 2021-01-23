    private async System.Threading.Tasks.Task WriteToFile()
            {
                // Get the text data from the textbox. 
                byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("Some Data to write\n".ToCharArray());
    
                // Get the local folder.
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
    
                // Create a new folder name DataFolder.
                var dataFolder = await local.CreateFolderAsync("DataFolder",
                    CreationCollisionOption.OpenIfExists);
    
                // Create a new file named DataFile.txt.
                var file = await dataFolder.CreateFileAsync("DataFile.txt",
                CreationCollisionOption.OpenIfExists);
    
                // Write the data from the textbox.
                using (var s = await file.OpenStreamForWriteAsync())
                {
                    s.Seek(0, SeekOrigin.End);
                    s.Write(fileBytes, 0, fileBytes.Length);
                }
    
            }
