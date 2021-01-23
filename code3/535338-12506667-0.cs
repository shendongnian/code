            Dictionary<string,Dictionary<string,string> > FileResponse = new Dictionary<string, Dictionary<string,string>>();
           Dictionary<string, string> ReturnDictionary = new Dictionary<string, string>();
           try
           {
                using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
               {
                   using (IsolatedStorageFileStream fileReader = new IsolatedStorageFileStream(DisplayMessage.Storage_Directory,FileMode.Open, FileAccess.ReadWrite, isolatedStorage))
                    {
                        DataContractSerializer datacontract = new DataContractSerializer(typeof(Dictionary<string, Dictionary<string,string>>));
                        FileResponse = (Dictionary<string, Dictionary<string,string>>)datacontract.ReadObject(fileReader);
                        ReturnDictionary = FileResponse[Key];
                    }
                }
           }
           catch (Exception ex)
            {
            }
            return (ReturnDictionary);
        }
       public void FileWrite(string Key,Dictionary<string, string> FiletoStore)
        {
           try
            {
               using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    Dictionary<string, Dictionary<string, string>> StoredDictionary = new Dictionary<string, Dictionary<string, string>>();
                    if (!isolatedStorage.FileExists(DisplayMessage.Storage_Directory))
                   {
                       using (IsolatedStorageFileStream IsolatedfileStream = new IsolatedStorageFileStream(DisplayMessage.Storage_Directory, FileMode.OpenOrCreate, isolatedStorage))
                       {
                            DataContractSerializer datacontract = new DataContractSerializer(typeof(Dictionary<string, Dictionary<string, string>>));
                           StoredDictionary.Add(Key, FiletoStore);
                           datacontract.WriteObject(IsolatedfileStream, StoredDictionary);
                          IsolatedfileStream.Close();
                        }
                    }
                   else
                    {
                        using (IsolatedStorageFileStream IsolatedfileStream = new IsolatedStorageFileStream(DisplayMessage.Storage_Directory, FileMode.Open, isolatedStorage))
                        {
                            DataContractSerializer datacontract = new DataContractSerializer(typeof(Dictionary<string, Dictionary<string, string>>));
                           StoredDictionary.Add(Key, FiletoStore);
                           datacontract.WriteObject(IsolatedfileStream, StoredDictionary);
                          IsolatedfileStream.Close();
                       }
                  }
               }
           }
           catch (Exception ex)
          {
           }
        }
