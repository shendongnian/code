    MethodInfo mi = type.GetMethod("Quack", 
                        BindingFlags.Instance | BindingFlags.Public, 
                        null, 
                        new[] { typeof(int), typeof(int), typeof(int) }, 
                        null);
    if (mi != null && typeof(string).IsAssignableFrom(mi.ReturnType))
    {
        string result = (string)mi.Invoke(objFoo, new object[] { 1, 2, 3 });
    }
