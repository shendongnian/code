    public async Task Initialize()
            {   
                IReadOnlyList<StorageFile> storageFiles = await KnownFolders.PicturesLibrary.GetFilesAsync();              
                foreach (var storageFile in storageFiles)
                {
                    var image = new Image();
                    image.Source = await GetBitmapImageAsync(storageFile);
                    Images.Add(image);
                }
            }
    
            public async Task<BitmapImage> GetBitmapImageAsync(StorageFile storageFile)
            {
                BitmapImage bitmapImage = new BitmapImage();
                IAsyncOperation<IRandomAccessStream> operation = storageFile.OpenAsync(FileAccessMode.Read);
                IRandomAccessStream stream = await operation;
                bitmapImage.SetSource(stream);
                return bitmapImage;
            }
