    class CustomClassToStringConverter : IValueConverter
    {
    	public static CustomClassToStringConverter Instance = new CustomClassToStringConverter();
    
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return ((CustomClass)value).Text;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return new CustomClass() { Text = (string)value };
    	}
    }
