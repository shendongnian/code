    public static string ConvertNumericTo(this object o, CultureInfo to)
    {
    	if (o == null) return "";
    
    	var s = o.ToString();
    	for (int i = 0; i <= 9; i++)
    	{
    		s = s.Replace(i.ToString(), to.NumberFormat.NativeDigits[i]);
    	}
    
    	return s;
    }
    // usage example
    var myNumber = 0123456789.4;
    var converted = myNumber.ConvertNumericTo(new CultureInfo("fa-IR")); // output: ۱۲۳۴۵۶۷۸۹.۴
