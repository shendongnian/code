    static void Main(string[] args)
    {
        Console.BufferWidth = 200;
        Console.WindowWidth = 140;
               
        PropertyInfo pi1 = typeof(ClassA).GetProperties()
            .Where(x => x.Name == "ValueA").Single();
        PropertyInfo pi2 = typeof(ClassB).GetProperties()
            .Where(x => x.Name == "ValueA").Single();
        PropertyInfo pi0 = typeof(ClassA).GetProperties()
            .Where(x => x.Name == "ValueB").Single();
        PropertyInfo pi3 = typeof(ClassB).GetProperties()
            .Where(x => x.Name == "ValueB").Single();
        PropertyInfo pi4 = typeof(ClassC).GetProperties()
            .Where(x => x.Name == "ValueA").Single();
        PropertyInfo pi5 = typeof(ClassC).GetProperties()
            .Where(x => x.Name == "ValueB").Single();
    
                
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi1, pi1.ReflectedType, pi1.DeclaringType, pi1.MemberType, pi1.MetadataToken, pi1.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi2, pi2.ReflectedType, pi2.DeclaringType, pi2.MemberType, pi2.MetadataToken, pi2.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi0, pi0.ReflectedType, pi0.DeclaringType, pi0.MemberType, pi0.MetadataToken, pi1.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi3, pi3.ReflectedType, pi3.DeclaringType, pi3.MemberType, pi3.MetadataToken, pi3.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi4, pi4.ReflectedType, pi4.DeclaringType, pi4.MemberType, pi4.MetadataToken, pi4.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi5, pi5.ReflectedType, pi5.DeclaringType, pi5.MemberType, pi5.MetadataToken, pi5.Module);
    
        // these two comparisons FAIL
        Console.WriteLine("pi1 == pi2: {0}", pi1 == pi2);
        Console.WriteLine("pi1.Equals(pi2): {0}", pi1.Equals(pi2));
    
        // this comparison passes
        Console.WriteLine("pi1.DeclaringType == pi2.DeclaringType: {0}", pi1.DeclaringType == pi2.DeclaringType);
    
    
        pi1 = typeof(ClassA).GetProperties()
            .Where(x => x.Name == "ValueB").Single();
    
        pi2 = typeof(ClassB).GetProperties()
            .Where(x => x.Name == "ValueB").Single();
    
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi1, pi1.ReflectedType, pi1.DeclaringType, pi1.MemberType, pi1.MetadataToken, pi1.Module);
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", pi2, pi2.ReflectedType, pi2.DeclaringType, pi2.MemberType, pi2.MetadataToken, pi2.Module);
    
        // these two comparisons FAIL
        Console.WriteLine("pi1 == pi2: {0}", pi1 == pi2);
        Console.WriteLine("pi1.Equals(pi2): {0}", pi1.Equals(pi2));
                
                
        Console.ReadKey();
    }
    class ClassA
    {
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
    class ClassB : ClassA
    {
        public new int ValueB { get; set; } 
    }
    class ClassC
    {
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
