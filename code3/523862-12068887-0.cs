    public static BitmapImage convertFileToBitmapImage(string filePath)
    {
        BitmapImage bmp = null;
        Uri jpegUri = new Uri(filePath, UriKind.Relative);
        StreamResourceInfo sri = Application.GetResourceStream(jpegUri);
        AutoResetEvent bitmapInitializationEvt = new AutoResetEvent(false);
        Deployment.Current.Dispatcher.BeginInvoke(new Action(() => {
            bmp = new BitmapImage();
            bmp.SetSource(sri.Stream);
            bitmapInitializationEvt.Set();
        }));
        bitmapInitializationEvt.WaitOne();
        return bmp;
    }
