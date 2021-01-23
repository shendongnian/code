    public class StringEmptyConverter : IValueConverter {
    
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          return string.IsNullOrEmpty((string)value) ? "Placeholder Message" : value;
        }
    
    public object ConvertBack(
          object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          throw new NotSupportedException();
        }
    
    }
