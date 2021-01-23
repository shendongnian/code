    public class ActiveProjectCheckConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        string first = values[0] as string;
        string second = values[1] as string;
        return !string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second) && first == second;
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
