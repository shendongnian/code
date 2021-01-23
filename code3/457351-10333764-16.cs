    public static void FooDynamic(object o) 
    {
        Type t = typeof(MainClass);
        t.InvokeMember("Foo", System.Reflection.BindingFlags.InvokeMethod, null, t, new object[] { o } ); 
    }
