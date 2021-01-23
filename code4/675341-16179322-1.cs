    public class ActiveProjectCheckConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        Project first = values[0] as Project;
        Project second = values[1] as Project;
        if (first == null || second == null)
          return new SolidColorBrush();
        return first.Name == second.Name ? new SolidColorBrush(Colors.Red) : new SolidColorBrush();
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
