            BitmapImage bi = new BitmapImage();
 
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(this.ImageLocation, FileMode.Open, FileAccess.Read))
                {
                    bi.SetSource(fileStream);
                }
            }
            return bi;
