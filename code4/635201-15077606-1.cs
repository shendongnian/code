    public class DivMulAddMultiConverter : IMultiValueConverter
    	{
    		#region Implementation of IMultiValueConverter
    
    		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    		{
    			if (targetType != typeof(double)) throw new ArgumentException("Expected a target type of Double", "targetType");
    			if (values == null || values.Length <= 0) return 0.0;
    
    			var cur = System.Convert.ToDouble(values[0]);
    			if(values.Length > 1)
    				cur /= System.Convert.ToDouble(values[1]);
    			if(values.Length > 2)
    				cur *= System.Convert.ToDouble(values[2]);
    			for(int i = 3; i < values.Length; i++)
    				cur += System.Convert.ToDouble(values[i]);
    
    			return cur;
    		}
    
    		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    		{
    			throw new NotImplementedException();
    		}
    
    		#endregion
    	}
