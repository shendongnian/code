    public class ElementOfListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IList && parameter is int)
            {
                var lst = value as IList;
                int pos = (int)parameter;
                if (lst.Count >= pos)
                {
                    return lst[pos];
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
