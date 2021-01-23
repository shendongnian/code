     public class IsSelectedToZoomConverter :DependencyObject, IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = (bool) value;
            return val ? Double.NaN : 1.0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
