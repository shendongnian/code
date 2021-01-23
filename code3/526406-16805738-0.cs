    public class PercentageConverter : IValueConverter
    {
    	//E.g. DB 0.042367 --> UI "4.24 %"
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		var fraction = decimal.Parse(value.ToString());
    		return fraction.ToString("P2");
    	}
    
    	//E.g. UI "4.2367 %" --> DB 0.042367
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		//Trim any trailing percentage symbol that the user MAY have included
    		var valueWithoutPercentage = value.ToString().TrimEnd(' ', '%');
    		return decimal.Parse(valueWithoutPercentage)/100;
    	}
    }
