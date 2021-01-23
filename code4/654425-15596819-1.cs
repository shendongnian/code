    public class ImageSourceConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source = value as string;
            if (source != null)
            {
                return new System.Windows.Media.Imaging.BitmapImage 
                { 
                    UriSource = new Uri(source, UriKind.Absolute) 
                };
            }
            return source;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
