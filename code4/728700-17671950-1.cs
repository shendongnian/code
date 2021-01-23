    public class LocalFileStorage: IRepository<byte[]> 
        {
            private readonly string _fileName;
    
            public LocalFileStorage(string fileName)
            {
                _fileName = fileName;
            }
    
            public async Task<byte[]> LoadAsync()
            {
                try
                {
                    var file = await GetFileAsync();
                    using (var stream = await file.OpenStreamForReadAsync())
                    {
                        var buffer = new byte[stream.Length];
                        await stream.ReadAsync(buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Unable load data from repository", e);
                }
            }
    
            public async Task SaveAsync(byte[] buffer)
            {
                try
                {
                    var file = await GetFileAsync();
                    using (var stream = await file.OpenStreamForWriteAsync())
                    {
                        await stream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Unable save data to repository", e);
                }
            }
    
            private async Task<StorageFile> GetFileAsync()
            {
                StorageFile file = null;
                var notFound = false;
    
                try
                {
                    file = await ApplicationData.Current.LocalFolder.GetFileAsync(_fileName);
                }
                catch (FileNotFoundException)
                {
                    notFound = true;
                }
    
                if (notFound)
                {
                    file = await ApplicationData.Current.LocalFolder.CreateFileAsync(_fileName);
                }
    
                return file;
            }
        }
