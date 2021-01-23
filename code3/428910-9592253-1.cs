    public class ColorConverter : IValueConverter
    {
      
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {      
            return new SolidColorBrush(Colors.Red);
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
