    public static void F<T>()
    {
    	if ((typeof(IEnumerable).IsAssignableFrom(typeof(T))))
    	{
    		Console.WriteLine ("{0} is IEnumerable", typeof(T).Name);
    	}
    }
