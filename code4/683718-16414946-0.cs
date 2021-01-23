    public class InMemoryImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var image = new BitmapImage();
            var memoryStream = new MemoryStream((byte[])value);
            image.SetSource(memoryStream);
            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
            return null;
        }
    }
