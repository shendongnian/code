    public class CustomNullToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object NullValue { get; set; }
        public object NotNullValue { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return NullValue;
            return NotNullValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
