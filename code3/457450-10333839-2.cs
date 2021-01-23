    void loadImage() { 
            BitmapImage bi = new BitmapImage();
       
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isfs = isf.OpenFile("0.jpg", FileMode.Open, FileAccess.Read))
                {
                    bi.SetSource(isfs);
                }
            }
            MyImage.Source = bi;    
        }
    }
