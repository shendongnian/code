    public class DateConverter:IValueConverter
    {
        private const string NoDate = "Дата отсутствует";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                var date = (DateTime) value;
                if(date==DateTime.MinValue)
                    return NoDate;
                return date.ToString();
            }
            return NoDate;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
