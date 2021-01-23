    public class BetweenTimesMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var time1 = (DateTime)values[0];
            var time2 = (DateTime)values[1];
            var current = DateTime.Now;
            return time1 > current && time2 < current;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
