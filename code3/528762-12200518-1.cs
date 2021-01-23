    public class ListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {
            var enumerable = value as IEnumerable;
            if (enumerable == null)
                return string.Empty;
            return String.Join(", ", enumerable.ToArray());
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
