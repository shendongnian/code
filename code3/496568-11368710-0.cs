    public static bool IsTypeSubclassOf(Type subclass, string baseClassFullName)
    {
        while (subclass != typeof(object))
        {
        	if (subclass.FullName == baseClassFullName)
        		return true;
        	else
        		subclass = subclass.BaseType;
        }
        return false;
    }
