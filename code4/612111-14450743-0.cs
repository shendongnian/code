        public static bool WriteFileToIsolatedStorage(String content, String fileName)
        {
            bool result = false;
            MessageBox.Show(Leser.GetVersionInfo(content));
            try
            {
                using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Truncate, store))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
