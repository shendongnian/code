        private async Task<string> ReadFileAsync(IStorageFile storageFile)
        {
            var fileContent = await FileIO.ReadTextAsync(storageFile)
                                          .ConfigureAwait(false);
            for (Int64 i = 0; i < 10000000000; i++)
            { }
            return fileContent; 
         }
