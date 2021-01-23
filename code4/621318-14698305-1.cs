    public class TextToStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string && !string.IsNullOrEmpty(value.ToString()))
            {
                return new string('*', value.ToString().Length -1) + value.ToString().Last().ToString();
            }
            return string.Empty;
        }
       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
