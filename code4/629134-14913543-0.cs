    public class CollectionLengthToVisibility : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            var collection = value as System.Collections.IEnumerable;
            if (collection == null)
                throw new ArgumentException("value");
              
            if (collection.Cast<object>().Any())
                   return Visibility.Visible;
            else
                   return Visibility.Collapsed;    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    
    
    }
