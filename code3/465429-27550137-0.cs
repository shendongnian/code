    public static class ObjectExtensions
    {
    	public static bool Isnt(this object source, Type targetType)
    	{
    		return source.GetType() != targetType;
    	}
    }
