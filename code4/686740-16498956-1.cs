    using System;
    
    class BaseClass
    {
        public BaseClass()
        {
            VirtualMethod();
            Console.WriteLine("BaseClass ctor body");
        }
        
        public virtual void VirtualMethod()
        {
            Console.WriteLine("BaseClass.VirtualMethod");
        }
    }
    
    class DerivedClass : BaseClass
    {
        int ignored = ExecuteSomeCode();
        
        public DerivedClass() : base()
        {
            Console.WriteLine("DerivedClass ctor body");
        }
        
        static int ExecuteSomeCode()
        {
            Console.WriteLine("Method called from initializer");
            return 5;
        }
    
        public override void VirtualMethod()
        {
            Console.WriteLine("DerivedClass.VirtualMethod");
        }
    }
    
    class Test
    {
        static void Main()
        {
            new DerivedClass();
        }
    }
