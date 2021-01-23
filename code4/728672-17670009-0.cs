    public class NullToVisibiltyConverter : IValueConverter {
      public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
        return value == null ? Visibility.Collapsed : Visibility.Visible;
      }
      public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
