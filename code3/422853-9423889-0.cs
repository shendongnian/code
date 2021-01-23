    var bmp = new WriteableBitmap(bitmapImage);
    using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = storage.CreateFile(@"MyFolder\file.jpg"))
            {
                bmp.SaveJpeg(stream, 200, 100, 0, 95);
                stream.Close();
            }
        }
