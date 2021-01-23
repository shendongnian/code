    void Main()
    {
        var a = "hello";//5;
        var b = "hello"; 
    
        var type1 = a.GetType();
        var type2 = b.GetType();
    
        var t = typeof(FooClass);
        
        var methods = t.GetMethods();
        
        foreach(var method in methods)
        {
            var parameters = method.GetParameters();
    
            if(parameters.Length == 2)
            {
                if(parameters[0].ParameterType == type1 
                   && parameters[1].ParameterType == type2)
                {
                    method.Invoke(this, new object[]{ a, b });
                }
            }
        }
    }
    
    public static class FooClass
    {
        public static void Foo(int i, string s)
        {
            "Foo1".Dump();
        }
        
        public static void Foo(string s, string s2)
        {
            "Foo2".Dump();
        }
    }
