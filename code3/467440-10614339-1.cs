    public class AtleastOneEmptyConverter : IMultiValueConverter
    {
        public object Convert
            (object[] values, Type targetType,
             object parameter, CultureInfo culture)
        {
            return values.Cast<string>().Any(val => string.IsNullOrEmpty(val));
        }
        public object[] ConvertBack
            (object value, Type[] targetTypes,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
