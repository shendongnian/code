    using System;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.Storage.Streams;
    public async Task<byte[]> GetBytesFromFile(StorageFile file)
    {
        byte[] fileBytes = null;
        using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
        {
            fileBytes = new byte[stream.Size];
            using (DataReader reader = new DataReader(stream))
            {
                await reader.LoadAsync((uint)stream.Size);
                reader.ReadBytes(fileBytes);
            }
        }
    
        return fileBytes;
    }
