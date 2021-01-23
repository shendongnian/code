    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                double divisor = 0.0;
                double _val = 0.0;
                if (double.TryParse(value.ToString(), out _val) && double.TryParse(parameter.ToString(), out divisor))
                {
                    return _val / divisor;
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
