    using (sc = new ServiceClient())
    {
        using (MemoryStream ms = new MemoryStream(sc.GetImage()))
        {
            _display = new BitmapImage();
            _display.BeginInit();
            _display.CacheOption = BitmapCacheOption.OnLoad;
            _display.StreamSource = ms;
            _display.EndInit();
        }
    }
    
    Display = _display;
