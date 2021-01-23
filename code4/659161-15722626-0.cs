       public sealed class GenderToBackgroundConverter : IValueConverter
       {
    
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value is string) {
    			if (Convert.ToString(value) == "m") {
    				return Colors.Blue;
    			} else {
    				return Colors.Pink;
    			}
    		}
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
