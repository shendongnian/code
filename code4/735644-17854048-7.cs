    public static bool IsExplicitInterfaceImplementation(PropertyInfo property)
    {
    	// At least one accessor must exists, I arbitrary check first for
    	// get one. Note that in Managed C++ (not C++ CLI) these methods
    	// are logically separated so they may follow different rules (one of them
    	// is explicit and the other one is not). It's a pretty corner case
    	// so we may just ignore it.
    	if (property.GetMethod != null)
    		return IsExplicitInterfaceImplementation(property.GetMethod);
    
    	return IsExplicitInterfaceImplementation(property.SetMethod);
    }
