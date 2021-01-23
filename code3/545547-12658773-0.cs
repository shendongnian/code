    public static bool IsActionDelegate(Type sourceType)
    {
        if(sourceType.IsSubclassOf(typeof(MulticastDelegate)) && 
           sourceType.GetMethod("Invoke").ReturnType == typeof(void))
            return true;
        return false;
    }
