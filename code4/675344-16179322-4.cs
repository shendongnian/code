    public class ActiveProjectCheckConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        string first = values[0] as string;
        string second = values[1] as string;
        if (first == null || second == null)
          return new SolidColorBrush();
        return first == second ? new SolidColorBrush(Colors.Red) : new SolidColorBrush();
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
