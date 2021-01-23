    public static void Main()
    {
        Assembly asm = Assembly.ReflectionOnlyLoad("Source");
        Type t = asm.GetType("Test");
        MethodInfo m = t.GetMethod("TestMethod");
        ParameterInfo[] p = m.GetParameters();
        Console.WriteLine("\r\nAttributes for assembly: '{0}'", asm);
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(asm));
        Console.WriteLine("\r\nAttributes for type: '{0}'", t);
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(t));
        Console.WriteLine("\r\nAttributes for member: '{0}'", m);
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(m));
        Console.WriteLine("\r\nAttributes for parameter: '{0}'", p);
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(p[0]));
    }
