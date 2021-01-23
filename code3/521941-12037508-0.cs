            String sb;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    StreamReader reader = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, myIsolatedStorage));
                    sb = reader.ReadToEnd();
                    reader.Close();
                }
                if(!String.IsNullOrEmpty(sb))
                {
                     MessageBox.Show(sb);
                }
            }
