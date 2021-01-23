    var bitm = new BitmapImage();
    bitm.BeginInit();
    bitm.CacheOption = BitmapCacheOption.OnLoad; // load immediately
    bitm.UriSource = new Uri(images.ElementAt(i));
    bitm.EndInit();
    bitm.Freeze();
