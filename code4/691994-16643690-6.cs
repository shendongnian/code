    public class StringFormatConverter: IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        var param = values[0].ToString();
        var format = values[1].ToString();
        return String.Format(culture, format, param);
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
