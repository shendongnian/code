        [ValueConversion(typeof(bool), typeof(Visibility))]
        public class BoolToVisibilityConverter : IValueConverter
        {
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {
            var boolValue = (bool) value;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
          }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
            throw new NotImplementedException();
          }
        }
