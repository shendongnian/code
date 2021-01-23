    public class Text2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((GuiMode)value) {
                case GuiMode.OneText:
                    return Visibility.Collapsed;
                default:
                    return Visibility.Visible;
            }
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("This converter does not convert back.");
        }
    }
