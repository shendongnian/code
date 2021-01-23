    static int Depth(Type type)
    {
        int depth = 0;
        for(
            Type current = type; 
            current.IsGenericType && current.GetGenericTypeDefinition() == typeof(List<>) ;
            current = current.GetGenericArguments()[0] )
        {
            depth += 1;
        }
        return depth;
    }
    static int Depth<T>(this List<T> x) 
    // x is unused; you could eliminate it entirely. 
    {
        return Depth(typeof(List<T>));
    }
