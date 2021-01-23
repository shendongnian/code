    public void SaveOrReplace(string fileContent)
    {
        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (!storage.DirectoryExists("FX"))
                storage.CreateDirectory("FX");
            if (storage.FileExists(FilePath))
                storage.DeleteFile(FilePath);
            using (IsolatedStorageFileStream fileStream = storage.OpenFile(FilePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(fileContent);
                    writer.Dispose();
                }
                fileStream.Dispose();
            }
        }
    }
