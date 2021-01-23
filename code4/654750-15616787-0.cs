    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
        {
            // Unload all images so as to reclaim any allocated memory
            foreach (var child in VisualTreeHelperEx.GetVisualChildren(this.ImageList).Where(c => c is Image))
            {
                var image = child as Image;
                if (image != null)
                {
                    var bitmapImage = image.Source as BitmapImage;
                    if (bitmapImage != null)
                    {
                        System.Diagnostics.Debug.WriteLine("unloading " + bitmapImage.UriSource);
                        bitmapImage.UriSource = null;
                    }
                    image.Source = null;
                }
            }
        }
    }
