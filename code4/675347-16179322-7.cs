    public class ActiveProjectCheckConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        string first = values[0] as string;
        string second = values[1] as string;
        if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second) || first != second)
          return new SolidColorBrush();
        LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush {StartPoint = new Point(1, 0)};
        myLinearGradientBrush.GradientStops.Add(
          new GradientStop(Color.FromArgb(0, 255, 255, 255), 0.0));
        myLinearGradientBrush.GradientStops.Add(
          new GradientStop(Color.FromArgb(255, 255, 255, 255), 1.1));
        return myLinearGradientBrush;
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
