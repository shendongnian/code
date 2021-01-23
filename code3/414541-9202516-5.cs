    public class BoolToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null; 
           
            if ((bool)value == true)
                return "YES";
            else
                return "NO";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // this scenario is not needed since the text block is read only
            throw new NotImplementedException();
        }
    }
