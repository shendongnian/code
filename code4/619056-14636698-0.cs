    public class StringToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            return ((DateTime)value).ToString(parameter as string, CultureInfo.InvariantCulture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value as string))
            {
                return null;
            }
            try
            {
                DateTime dt = DateTime.ParseExact(value as string, parameter as string, CultureInfo.InvariantCulture);
                return dt as DateTime?;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
