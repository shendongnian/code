     public bool WriteImage(string imageName, Stream streamImage)
        {
            IsolatedStorageFile store = null;
            Stream stream = null;
            try
            {
                using (store = IsolatedStorageFile.GetUserStoreForSite())
                {                    
                    // Open/Create the file for writing
                    stream = new IsolatedStorageFileStream(imageName,
                        FileMode.Create, FileAccess.Write, store);
                    streamImage.CopyTo(stream);
                    
					stream.Close();
                    streamImage.Close();
                }
                return true;
            }
            catch (Exception ie)
            {
               //manage error the way you prefer (think especially to quota management)
            }
        }
