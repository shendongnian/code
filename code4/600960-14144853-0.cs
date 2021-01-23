    public class UserNameToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var username = (string)value;
            if (username == "System.Threading.Thread.CurrentPrincipal.Identity.Name")
              return true;
            return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
