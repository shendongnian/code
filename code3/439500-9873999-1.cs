    public static class MyExt 
    {
    	public static string ToFormattedString(this float This, string format, IFormatProvider provider)
    	{
    		return String.Format(provider,"{0}", new object[] {This});
    	}
    }
    //now this works
    var NoLongerBadResult = (100F).ToFormattedString("B", new CustomFormatter ());
