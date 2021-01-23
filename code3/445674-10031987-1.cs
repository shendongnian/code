    [ValueConversion(typeof(double), typeof(string))]
    public class isLessThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                if ((double)value < double.Parse((string)parameter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
