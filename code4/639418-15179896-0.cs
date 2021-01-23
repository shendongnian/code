    public class DarkenColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double percentage = 0.8;
            if (parameter != null)
            {
                double.TryParse(parameter.ToString(), out percentage);
            }
            if (value is SolidColorBrush)
            {
                Color color = (value as SolidColorBrush).Color;
                return new SolidColorBrush(Color.FromRgb((byte)(color.R * percentage), (byte)(color.G * percentage), (byte)(color.B * percentage)));
            }
            else if (value is Color)
            {
                Color color = (Color)value;
                return Color.FromRgb((byte)(color.R * percentage), (byte)(color.G * percentage), (byte)(color.B * percentage));
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
