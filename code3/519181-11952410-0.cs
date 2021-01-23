    [ValueConversion(typeof(DateTime), typeof(bool))]
    public class IsEqualOrGreaterThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            DateTime curDate = DateTime.Now;
    
            TimeSpan span = curDate.Subtract(date);
    
            return span.TotalDays > (int)parameter * 7;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
