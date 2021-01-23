    void ImgDownloader_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        var graphImage = e.Result;
        BitmapImage bitmap = new BitmapImage();
        bitmap.SetSource(graphImage);
        imgGraph.Source = bitmap;
        //Stop loading animation
        refreshProgressBar.IsIndeterminate = false;
    }
