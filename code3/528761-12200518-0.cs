    public class ListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {
            var enumerable = value as IEnumerable;
            if (enumerable == null)
                return string.Empty;
            return enumerable.Cast<object>()
                             .Aggregate((o1, o2) => o1.ToString() + ", " + o2.ToString());
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
