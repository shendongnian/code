    public class UriToImageConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This could be extended to accept a Uri as well
            string url = value as string;
            if (!string.IsNullOrEmpty(url))
            {
                return new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            else
            {
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
