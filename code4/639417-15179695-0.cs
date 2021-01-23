    public class DarkenColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Colors.Blue;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,     System.Globalization.CultureInfo culture)
        {
            return Colors.Gray;
        }
    }
