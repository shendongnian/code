     public class ServiceImageDownloader
    {
        private readonly BitmapImage _downloadedBmpImage = new BitmapImage();
        public ServiceImageDownloader()
        {
            _downloadedBmpImage.ImageOpened += DownloadedBmpImageImageOpened;
            _downloadedBmpImage.ImageFailed += DownloadedBmpImageImageFailed;
            _downloadedBmpImage.CreateOptions = BitmapCreateOptions.BackgroundCreation;
        }
        public void DownloadImage(string imageUri)
        {
          _downloadedBmpImage.UriSource = imageUri;
        }
        private void DownloadedBmpImageImageOpened(object sender, RoutedEventArgs e)
        {
            try
            {
                OnImageDownloaded(new WriteableBitmap(_downloadedBmpImage));
            }
            catch
            {
                //manage other classic errors
            }
        }
        private void OnImageDownloaded(WriteableBitmap wbImTemp)
        {
            //here you get your image as a writeableBmp and you can do whatever you wish,
			//as save it in your IS in your example
        }
    }
