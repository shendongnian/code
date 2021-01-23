    public static void F<T>()
    {
    	var isAssignable = typeof(IEnumerable).IsAssignableFrom(typeof(T));
    	Console.WriteLine ("{0} is {1} IEnumerable", typeof(T).Name, isAssignable ? "" : "not");
    }
