    public class FileReadWrite
    {
        public string FileName { get; set; }
        public FileReadWrite(string fileName)
        {
            FileName = fileName;
        }
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public async Task WriteDataCords(int numDataCodewords)
        {
            await _semaphore.WaitAsync();
            try
            {
                StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
                var storageFile = await storageFolder.GetFileAsync(FileName);
                string data = numDataCodewords.ToString();
                await FileIO.AppendTextAsync(storageFile, data);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task ReadDataCords()
        {
            await _semaphore.WaitAsync();
            try
            {
                StorageFolder storageFolder6 = KnownFolders.DocumentsLibrary;
                var storageFile7 = await storageFolder6.GetFileAsync(FileName);
                string text7 = await Windows.Storage.FileIO.ReadTextAsync(storageFile7);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
