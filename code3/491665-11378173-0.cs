     public class ConvertStringToDBNull : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cufo)
        {
            
            if (value is string)
            {
                if (value.ToString() == string.Empty)
                {
                    return DBNull.Value;
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cufo)
        {
            if (value is string)
            {
                if (value.ToString() == string.Empty)
                {
                    return DBNull.Value;
                }
            }
            return value;
        }
    }
