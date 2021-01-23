    public class GridCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            var count = (int)value;
            return count == 0? Visibility.Visible : Visibility.Collapsed;
        }
    }
 
