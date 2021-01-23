    public class UnitMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = (double)values[0];
            bool isMetric = (bool)values[1];
            string format = isMetric ? "{0:0.0}" : "{0:0.000}";
            return string.Format(format, value);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
