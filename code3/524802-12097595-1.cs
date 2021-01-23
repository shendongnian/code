    using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
    {
       IsolatedStorageFileStream fileStream = storage.OpenFile(app.getSettingsPath,FileMode.Open, FileAccess.Read);
       using (StreamReader reader = new StreamReader(fileStream ))
       {
          string line;
          while((line = reader.ReadLine()) != null)
          {
             // do your work here
          }
       }
    }
