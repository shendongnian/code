    public static void ClearCache(this DataContext context) 
     { 
        const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic; 
        var method = context.GetType().GetMethod("ClearCache", FLAGS); 
        method.Invoke(context, null); 
     } 
