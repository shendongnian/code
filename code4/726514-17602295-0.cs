    static void Main(string[] args)
    {
        Sample sampleInstance = new Sample();
        Type sampleType = sampleInstance.GetType();
        
        
        MethodInfo[] sampleMethods = 
            sampleType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
    
        foreach (MethodInfo method in sampleMethods)
        {
            var methodReturnType = method.ReturnType;
            Console.WriteLine(methodReturnType.FullName);
            foreach (FieldInfo field in methodReturnType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine("  {0}", field.Name);       
            }
        }
    
        Console.Read();
    }
