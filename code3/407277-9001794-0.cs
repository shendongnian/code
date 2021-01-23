    public class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double originalValue;
            double multiplier;
            if (value != null && double.TryParse(value.ToString(), out originalValue) &&
                parameter != null && double.TryParse(parameter.ToString(), out multiplier)) //Can be lots of things: sentinel object, NaN (not a number)...
            {
                return originalValue * multiplier;
            }
            else return 0.0;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
