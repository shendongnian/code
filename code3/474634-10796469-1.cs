    public class IdToEnabledConverter:IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return value != null && (int)value > 0;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
