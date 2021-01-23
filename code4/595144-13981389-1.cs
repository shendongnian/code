    public static class ObjectExtensions
    {
    	public static object OptionalParam<T>(this T value, T optionalValue = default(T))
    	{
    		return Equals(value,optionalValue) ? (object)DBNull.Value : value;
    	}
    }
