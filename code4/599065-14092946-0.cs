     public class IntToBooleanConverter : IValueConverter
	    {
	      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	      {
	        if (value is int)
			{
			    if ((int)value) == 1)
					return true;
				return false;
			}
	
	        return DependencyProperty.UnsetValue;
	      }
	
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	       if (value is bool)
			{
			    if ((bool)value) )
					return 1;
				return 0;
			}
	
	        return DependencyProperty.UnsetValue;
	    }
