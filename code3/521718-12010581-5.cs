    using System.Windows.Data;
    using System.Globalization;
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value is Color)
                return new SolidColorBrush((Color)value);
            return value;
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return null;
        }
    }
