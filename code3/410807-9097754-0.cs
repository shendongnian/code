    public class AlternateRowColour : IValueConverter
    {
        SolidColorBrush normal = new SolidColorBrush(Colors.Transparent);
        SolidColorBrush highlighted = new SolidColorBrush(Color.FromArgb(255, 241, 241, 241));
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var myValue = (bool)value
            return myValue ? highlighted : normal ;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
