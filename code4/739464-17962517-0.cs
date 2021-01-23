    public class BooleanToTextWrappingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool && (bool)value) ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is TextWrapping && (TextWrapping)value == TextWrapping.Wrap;
        }
    }
