    public static void Main() 
    {
        MethodInfo[] methodInfos = typeof(MyClass).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Console.WriteLine("The number of public methods is: {0}", methodInfos.Length);
        Int32 virtualCount = 0;
        foreach (MethodInfo methodInfo in methodInfos)
        {
            if (methodInfo.IsVirtual)
                ++virtualCount;
        }
        if (virtualCount == methods.Length)
            Console.WriteLine("All the methods are virtual!");
        else
            Console.WriteLine("Only {0}/{1} methods are virtual!", virtualCount, methods.Length); 	
    }
