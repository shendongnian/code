    public static bool IsNumericValue(string val, System.Globalization.NumberStyles NumberStyle)
    {
    	double result;
    	return Double.TryParse(val,NumberStyle,
    		System.Globalization.CultureInfo.CurrentCulture,out result);
    }
