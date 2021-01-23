    private void LoadIMG()
        {
            var bitmapImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
            bitmapImage.ImageOpened += bitmapImage_ImageOpened;
            bitmapImage.ImageFailed += bitmapImage_ImageFailed;
            bitmapImage.DownloadProgress += bitmapImage_DownloadProgress;
            bitmapImage.UriSource = new Uri("http://ds.serving-sys.com/BurstingRes///Site-16990/Type-0/7b912e70-352a-454f-8ea7-5d5ecd6ebfae.gif");
        }
        private void bitmapImage_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            
        }
        private void bitmapImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
        }
        private void bitmapImage_ImageOpened(object sender, RoutedEventArgs e)
        {
             var userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication(); 
             var writeableBitmap = new WriteableBitmap(sender as BitmapImage);
             var isolatedStorageFileStream = userStoreForApplication.CreateFile("Myfile.gif");
             writeableBitmap.SaveJpeg(isolatedStorageFileStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 85); 
        }
