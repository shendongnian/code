    [ValueConversion(typeof(int), typeof(string))]
    public class IntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = (int)value;
            return intValue != 0 ? intValue.ToString() : string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = 0;
            int.TryParse((string)value, out intValue);
            return intValue;
        }
    }
