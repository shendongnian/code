    private void AddImages(List<string> photoUrls)
    {
        PhotosView.Items.Clear();
        int nextIndex = 0;
        foreach (var url in photoUrls)
        {
            int n = nextIndex++;
            var image = new Image();
            var source = new BitmapImage(new Uri(url));
            source.DownloadProgress += (sender, args) => 
            {
                Debug.WriteLine("image {0} progress={1}%", n, args.Progress);
            };
            image.Source = source;
            image.Tag = source;
            PhotosView.Items.Add(image);
        }
    }
