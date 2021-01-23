    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,  object parameter, CultureInfo culture)
        {
            int i = int.Parse(value as string);
            // logic here
        }
     
        public object ConvertBack(object value, Type targetType,  object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
