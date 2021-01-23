    using System;
    
    class ClassA
    {
        public ClassA()
        {
            Console.WriteLine("Initialization");
        }  
    }
    
    class ClassB : ClassA
    {
        private readonly int ignoreMe = BeforeBaseConstructorCall();
        
        public ClassB()
        {
        }
        
        private static int BeforeBaseConstructorCall()
        {
            Console.WriteLine("Before new");
            return 0; // We really don't care
        }
    }
    
    class Test
    {
        static void Main()
        {
            new ClassB();
        }    
    }
