    public static bool Is<T1, T2, T3, T4>(this object obj)
    {
    	return 	obj is T1 ||
    			obj is T2 ||
    			obj is T3 ||
    			obj is T4;
    }
