    public static class ProductFactory
    {
    	public static IProducts<T> GetProductDAO<T>() where T : ISomeMarkerInterface, IProducts<T>, new()
    	{
    		return new T();
    	}
    }
