    public static main()
    {
        // Defined by the user:
        Type fieldType = typeof(double);
        
        // Using reflection:
        MethodInfo method = typeof(MyConvertingClass).GetMethod("Convert");
        method = method.MakeGenericMethod(fieldType);
        
        Console.WriteLine(method.Invoke(null, new object[] { fieldData }));
    }
