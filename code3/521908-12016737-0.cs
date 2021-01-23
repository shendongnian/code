    string tempJPEG = "image.jpg";
        void photoTask_Completed(object sender, PhotoResult e)
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }
                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(tempJPEG);
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(e.ChosenPhoto);
                WriteableBitmap wb = new WriteableBitmap(bitmap);
                // Encode WriteableBitmap object to a JPEG stream.
                Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                fileStream.Close();
            }
        }
    
    //Code to load image from IsolatedStorage anywhere in your app
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(tempJPEG, FileMode.Open, FileAccess.Read))
                {
                    bi.SetSource(fileStream);
                    this.img.Height = bi.PixelHeight;
                    this.img.Width = bi.PixelWidth;
                }
            }
            this.img.Source = bi;
        }
