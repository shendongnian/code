    public class LocalizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                return ((string)value).Translate(culture);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                return (string)value;
            }
            return null;
        }
    }
