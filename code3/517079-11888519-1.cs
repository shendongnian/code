    // Returns the number of days since last update of an entity
    public class DateConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{	    
    		if (value is IDatedEntity)
    		{
    			return DateTime.UtcNow.Substract(((IDatedEntity)value).UpdateDate).TotalDays;
    		}
    
    		return 0;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
