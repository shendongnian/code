    public static class ExceptionExtensions
    {
    	public static int HResultPublic(this Exception exception)
    	{
    		var hResult = exception.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(z => z.Name.Equals("HResult")).FirstOrDefault();
    		return (int)hResult.GetValue(exception, null);
    	}
    }
