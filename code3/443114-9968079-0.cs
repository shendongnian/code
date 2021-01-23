    public class NameConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		Named named = null;
    
    		Data1 d1 = value as Data1;
    		if (d1 != null)
    		{
    			named = d1.Xxx;
    		}
    		else
    		{
    			Data2 d2 = value as Data2;
    			if (d2 != null)
    			{
    				named = d2.Yyy;
    			}
    		}
    
    		if (named != null)
    		{
    			return named.Name;
    		}
    
    		return DependencyProperty.UnsetValue;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
