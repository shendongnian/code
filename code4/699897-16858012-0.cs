    public static class ObjectLoader
    {
    //----------------------------------------------------------------------
    // public static methods
    //----------------------------------------------------------------------
    public static object LoadFromAssembly(
        string srcAssembly,
        string typeName,
        Type derivesFrom)
    {
        return LoadFromAssembly(srcAssembly, typeName, derivesFrom, true);
    }
    public static object LoadFromAssembly(
        string srcAssembly,
        string typeName,
        Type derivesFrom, 
        bool throwOnLoadError)
    {
        if (srcAssembly == null)
            throw new ArgumentNullException("srcAssembly");
        else if (srcAssembly.Length == 0)
            throw new ArgumentException("Value may not be empty.", "srcAssembly");
        else if (typeName == null)
            throw new ArgumentNullException("typeName");
        else if (typeName.Length == 0)
            throw new ArgumentException("Value may not be empty.", "typeName");
        else if (derivesFrom == null)
            throw new ArgumentNullException("derivesFrom");
        object retVal = null;
        try
        {
            string srcAssemblyPath = Path.Combine(AppDir, srcAssembly);
            Assembly asm = Assembly.LoadFrom(srcAssemblyPath);
            object obj = asm.CreateInstance(typeName);
            if (obj != null && derivesFrom.IsAssignableFrom(obj.GetType()))
            {
                retVal = obj;
            }
            else if (obj != null) // wrong object, cleanup as needed
            {
                if (obj is IDisposable)
                    ((IDisposable)obj).Dispose();
            }
        }
        catch (Exception ex)
        {
            if (throwOnLoadError)
                throw;
            // otherwise null is returned...
        }
        return retVal;
    }
    //----------------------------------------------------------------------
    // private static methods
    //----------------------------------------------------------------------
    private static string AppDir
    {
        get
        {
            string appFullPath = Assembly.GetExecutingAssembly().GetName().CodeBase;
            return Path.GetDirectoryName(appFullPath);
        }
    }
    }
