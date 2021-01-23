    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    	public class MaxDecimalValueAttribute : ValidationAttribute
    	{
    		private double maximum;
    		public MaxDecimalValueAttribute(double maxVal)
    			: base("The given value is more than the maximum allowed.")
    		{
    			maximum = maxVal;
    		}
    		public override bool IsValid(object value)
    		{
    			var stringValue = value as string;
    			double numericValue;
    			if(stringValue == null)
    				return false;
    			else if(!Double.TryParse(stringValue, out numericValue) ||  numericValue > maximum)
    			{
    				return false;
    			}
			return true;
		}
	}
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class MinDecimalValueAttribute : ValidationAttribute
	{
		private double minimum;
		public MinDecimalValueAttribute(double minVal)
			: base("The given value is less than the minimum allowed.")
		{
			minimum = minVal;
		}
		public override bool IsValid(object value)
		{
			var stringValue = value as string;
			double numericValue;
			if (stringValue == null)
				return false;
			else if (!Double.TryParse(stringValue, out numericValue) || numericValue < minimum)
			{
				return false;
			}
			return true;
		}
	}
