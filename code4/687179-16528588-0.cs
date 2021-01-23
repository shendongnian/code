     private void SaveToIsolatedStorage(Stream imageStream, string fileName)
        {
            using (IsolatedStorageFile myIsoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsoStorage.FileExists(fileName))
                {
                    myIsoStorage.DeleteFile(fileName);
                }
                IsolatedStorageFileStream fileStream = myIsoStorage.CreateFile(fileName);
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(imageStream);
                WriteableBitmap mywb = new WriteableBitmap(bitmap);
                mywb.SaveJpeg(fileStream, mywb.PixelWidth, mywb.PixelHeight, 0, 95);
                fileStream.Close();
            }
            this.ReadFromIsolatedStorage("myImage.jpg");
        }
        private void ReadFromIsolatedStorage(string fileName)
        {
            WriteableBitmap bitmap = new WriteableBitmap(200, 200);
            using (IsolatedStorageFile myIsoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsoStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                {
                    bitmap = PictureDecoder.DecodeJpeg(fileStream);
                }
            }
            
            photoPreview.Source = bitmap;
        }
    public String myNote { get; set; }
       
        public String path
        {
            get;
            set;
        }
