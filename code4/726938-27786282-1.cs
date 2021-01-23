     using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (myIsolatedStorage.FileExists(FileName))
            {
                myIsolatedStorage.DeleteFile(FileName);
            }                
            using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(FileName, System.IO.FileMode.CreateNew))
            {                                        
                new BinarySerializationHelper().Serialize(fileStream, object);
            }
    }
