        private async void  Button_Click_1(object sender, RoutedEventArgs e)
        {
            // select document library in capabilities and declare .png file type
            string filename = "Logo.png";
            Windows.Storage.StorageFile sampleFile = await Windows.Storage.KnownFolders.DocumentsLibrary.GetFileAsync(filename);
            BitmapImage img = new BitmapImage();
            img = await LoadImage(sampleFile);
            myImage.Source = img;
        }
        private static async Task<BitmapImage> LoadImage(StorageFile file)
        {
            BitmapImage bitmapImage = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
            bitmapImage.SetSource(stream);
            return bitmapImage;
        }
