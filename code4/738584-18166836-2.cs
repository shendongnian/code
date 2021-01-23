    public async Task<String> ReadFile(String filepath)
    {
        return await await Task.Factory.StartNew<Task<String>>(async () =>
            {
                String filec = "";
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var stream = new IsolatedStorageFileStream(filepath, FileMode.Open, store))
                    {
                        using (StreamReader r = new StreamReader(stream))
                        {
                            filec = await r.ReadToEndAsyncThread();
                        }
                    }
                }
                return filec;
            });
    }
