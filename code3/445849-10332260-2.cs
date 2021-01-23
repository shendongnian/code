    public class UpsideDownRowConverter : IMultiValueConverter
    {
    	public int RowCount
    	{
    		get;
    		set;
    	}
    
    	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (values.Length == 2 && values[0] is int && values[1] is int)
    		{
    			var row = (int)values[0];
    			var rowSpan = (int)values[1];
    
    			row = this.RowCount - row - rowSpan;
    
    			return row;
    		}
    
    		return DependencyProperty.UnsetValue;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
