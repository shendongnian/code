    public class OnOffImageConverter : IValueConverter
        {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
            {
            if ((bool)value)
                {
                return new BitmapImage (new Uri ("Images/On.png", UriKind.Relative));
                }
            else
                {
                return new BitmapImage (new Uri ("Images/Off.png", UriKind.Relative));
                }
            }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
            {
            throw new NotImplementedException ();
            }
        }
