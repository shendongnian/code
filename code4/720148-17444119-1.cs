    public class FindCentreMultiConverter : IMultiValueConverter
    {
      public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        var point1 = (double)values[0];
        var point2 = (double)values[1];
        return (double)((point1 + point2) / 2.0d);
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
