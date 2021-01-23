    public class SubstractConverter
            : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any())
            {
                var result = System.Convert.ToDouble(values.First());
                var toSubstract = values.Skip(1);
                foreach (var number in toSubstract)
                {
                    result -= System.Convert.ToDouble(number);
                }
                return result;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
