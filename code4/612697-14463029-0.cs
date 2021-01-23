    Binding = new Binding(stat.Key) { Converter = new StatisticPersonalizedValueConverter() }
    public class StatisticPersonalizedValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is StatisticPersonalizedValue)
            {
                return (value as StatisticPersonalizedValue).Value;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
