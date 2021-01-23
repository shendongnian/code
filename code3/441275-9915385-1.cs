    [ValueConversion(typeof(string), typeof(string))]
    public class ReplaceCarriageReturnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value as string == null ? string.Empty : (value as string).Replace("\r", " - "); ;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
