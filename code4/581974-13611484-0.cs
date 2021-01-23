    private void SetImage(string filename, int pageNumber)
    {
        using (BitmapImage bitmap = new BitmapImage())
        {
            bitmap.BeginInit();
            //I am trying to make the Image control use as less memory as possible
            //so I prevent caching
            bitmap.CacheOption = BitmapCacheOption.None;
            bitmap.UriSource = new Uri(filename);
            bitmap.EndInit();
            this.images[pageNumber].Source = bitmap;
        }
    }
