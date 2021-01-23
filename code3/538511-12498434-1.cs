    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double source = (double)value;
            return source < 0 ? Brushes.Red : Brushes.Green;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // We don't care about this one here
            throw new NotImplementedException();
        }
    }
