    public class SerializeHelper
        {
            //named mutex
            private static Mutex mutex = new Mutex(false, "BackgroundAgentDemo1");
            
            public static void SaveData<T>(string fileName, T dataToSave)
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    try
                    {
                        mutex.WaitOne();
                        if (store.FileExists(fileName))
                        {
                            store.DeleteFile(fileName);
                        }
    
                        using (IsolatedStorageFileStream stream = store.OpenFile(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            var serializer = new DataContractSerializer(typeof(T));
                            serializer.WriteObject(stream, dataToSave);
                        }
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        return;
                    }
                    finally
                    {
                        try { mutex.ReleaseMutex(); }
                        catch (Exception) { } //mutex.Dispose();
                    }
                }
            }
    
            public static T ReadData<T>(string fileName)
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                {
    
                    if (store.FileExists(fileName))
                    {
                        using (IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                        {
    
                            try
                            {
                                var serializer = new DataContractSerializer(typeof(T));
                                return (T)serializer.ReadObject(stream);
                                //XmlSerializer serializer = new XmlSerializer(typeof(FacebookAccess));
                                //return (FacebookAccess)serializer.Deserialize(stream);
                            }
                            catch (Exception)
                            {
                                return default(T);
                            }
                        }
                    }
                    return default(T);
                }
            }
    
        }
