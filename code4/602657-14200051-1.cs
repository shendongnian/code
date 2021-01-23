      public class AlarmLevelConverter: IValueConverter {
    
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          return ((int)(value) > 5);
        }
    
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          throw new NotSupportedException();
        }
      }
