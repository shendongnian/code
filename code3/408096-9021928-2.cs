    public class NullableIntConverter : IValueConverter
    {
        public static NullableIntConverter Instance = new NullableIntConverter();
	    public void ConvertBack(object value, ...)
	    {
		    int intValue = 0;
		    if (int.TryParse((string)value, out intValue))
			    return intValue;
			    
    		return null;
	    }
    
	    public void Convert(object value, ...)
	    {
            return value.ToString();
    	}
    }
