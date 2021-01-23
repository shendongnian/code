    public class MultiParamConverter : IMultiValueConverter
    {
       public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
          return new Tuple<string, string>((string)values[0], (string)values[1]);;
       }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    }
