    [ValueConversion(typeof(double), typeof(double))]
    public class RoundConverter : IValueConverter {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    		return Math.Ceiling((double)value);
    	}
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    		return value;
    	}
    }
