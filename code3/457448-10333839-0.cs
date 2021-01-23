    void loadImage() { // The image will be read from isolated storage into the following byte array
    
            byte[] data;
    
            // Read the entire image in one go into a byte array
    
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isfs = isf.OpenFile("0.jpg", FileMode.Open, FileAccess.Read))
                {
                    data = new byte[isfs.Length];
                    isfs.Read(data, 0, data.Length);
                    isfs.Close();
                }
            }
    
            MemoryStream ms = new MemoryStream(data);
            BitmapImage bi = new BitmapImage();
            bi.SetSource(ms);
    
            MyImage.Source = bi;    
        }
    }
