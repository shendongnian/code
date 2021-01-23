    [ValueConversion(typeof(int), typeof(string)]
    public class MyConverter : MarkupExtension, IMultiValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    	    int tagId = (int)values[0];
    	    int itemCount = (int)values[1];
    	
    		if (itemCount >= 10 && tagId < 10)
    		{
    		    return "0" + tagId;
    		}
    		
    		return tagId;
        }
    }
