    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                   CultureInfo culture)
        {
            if (value != null && value is bool && parameter != null)
            {
                var bValue = (bool) value;
                var visibility = (Visibility)Enum.Parse(
                typeof (Visibility), parameter.ToString(),true);
                if (bValue) return visibility;
                return visibility == 
                Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
      
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                       CultureInfo culture)
        {
             throw new NotImplementedException();
        }
    }
