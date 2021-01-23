    [ValueConversion(typeof(double), typeof(double))]
    public class DivideBy20Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var f = (double) value;
            return f/20.0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var f = (double)value;
            return f * 20.0;
        }
    }
