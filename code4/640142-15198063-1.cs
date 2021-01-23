    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value;
            var imageUrl = value as string;
            if (imageUrl != null)
            {
                var buffer = (new WebClient().DownloadData(imageUrl));
                if (buffer != null)
                {
                    // create an appropriate file path here
                    File.WriteAllBytes("CachedImage.jpg", buffer);
                    var image = new BitmapImage();
                    result = image;
                    using (var stream = new MemoryStream(buffer))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                    }
                }
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
