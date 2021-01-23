    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color labelColor;
            // Implement your conversion code here ...
            return labelColor;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // As far as I understood your question you
            // will not need to convert back.
            return DependencyProperty.UnsetValue;
        }
    }
