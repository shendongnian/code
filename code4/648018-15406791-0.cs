    public class NullableValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              CultureInfo culture)
        {
            return value == null ? string.Empty : value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  CultureInfo culture)
        {
            string s = value as string;
            int result;
            if (!string.IsNullOrWhiteSpace(s) && int.TryParse(s, out result))
            {
                return result;
            }
            return null;
        }
    }
