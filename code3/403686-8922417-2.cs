    using System;
    
    class Base
    {
        public virtual void M(int x)
        {
            // This isn't called
        }   
    }
    
    class Derived : Base
    {
        public override void M(int x = 5)
        {
            Console.WriteLine("Derived.M: {0}", x);
        }
        
        public void RunTests()
        {
            M();      // Prints Derived.M: 0
        }
    
        static void Main()
        {
            new Derived().RunTests();
        }
    }
