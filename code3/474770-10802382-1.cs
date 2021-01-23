      public class ColorConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          if (value is SolidColorBrush)
          {
            var brush = value as SolidColorBrush;
            return brush.Color;
          }
          return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          throw new NotImplementedException();
        }
      }
