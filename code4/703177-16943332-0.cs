    [ValueConversion(typeof(decimal), typeof(Brush))]
    public class BusVoltagesColorConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is decimal))
            {
                return DependencyProperty.UnsetValue;
            }
            var d = (decimal) value;
            decimal lowerLimit = 0.95m; //TODO get your value from your user settings here
            decimal upperLimit = 1.05m;
            if (d < lowerLimit || d > upperLimit)
            {
                return Brushes.Red;
            }
            return Brushes.Black;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new BusVoltagesColorConverter();
        }
    }
