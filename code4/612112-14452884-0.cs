    public static bool WriteFileToIsolatedStorage(String content, String fileName)
        {
            bool result = false;
            //MessageBox.Show(Leser.GetVersionInfo(content));
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            
            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.Create, store));
            try
            {
                writer.Write(content);
                writer.Flush();
                writer.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            StreamReader reader = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, store));
            string rawData = reader.ReadToEnd();
            reader.Close();
            
            return result;
        }
