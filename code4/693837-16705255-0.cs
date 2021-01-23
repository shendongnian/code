    IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
    if (store.FileExists("services.txt"))
    {
        using (var stream = new IsolatedStorageFileStream("services.txt", FileMode.Open, store))
        {
            using (var fileReader = new StreamReader(stream))
            {
                result = fileReader.ReadToEnd();
            }
        }
    }
