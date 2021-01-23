    using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if(list.Count == 0)
            list = new List<Record>() { new Record { Date = DateTime.Today, Value = 0 }};
        if (isf.FileExists(fileName))
        {
            isf.DeleteFile(fileName);
        }
    }
