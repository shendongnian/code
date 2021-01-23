    public class MyCountConverter: IValueConverter {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        if (value == null)
          return value;
        return String.Format(culture, AppResources.TextResource, value);
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
