    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;
        string imageBase64String = (string)value;
        byte[] imageAsBytes = Convert.FromBase64String(imageBase64String);
        using (var ms = new MemoryStream(imageAsBytes))
        {
            var decoder = System.Windows.Media.Imaging.BitmapDecoder.Create(ms, BitmapCreateOptions.None, BitmapCacheOptions.OnLoad);
            return decoder.Frames[0];
        }
    } 
