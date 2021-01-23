    public class DoubleMultiplyingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var factor = System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
            var val = System.Convert.ToDouble(value);
            return val * factor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
