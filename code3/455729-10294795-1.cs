            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                
                using (IsolatedStorageFileStream isfs = isf.OpenFile(uri, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[isfs.Length];
                    isfs.Read(data, 0, data.Length);
                    isfs.Close();
                }
            }
            MemoryStream ms = new MemoryStream(data);
            BitmapImage bi = new BitmapImage();
            bi.SetSource(ms);
    If you give the image name as image then set the source as bi:
            image.source = bi;
        
