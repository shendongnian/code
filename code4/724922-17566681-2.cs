    public class TemplateSelectorConverter : IValueConverter
    {
        public DataTemplate TrueTemplate { get; set; }
    
        public DataTemplate FalseTemplate { get; set; }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((bool) value))
                return TrueTemplate;
            return FalseTemplate;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
