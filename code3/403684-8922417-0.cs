    using System;
    
    class Base
    {
        public virtual void M(string text = "base-default")
        {
            Console.WriteLine("Base.M: {0}", text);
        }   
    }
    
    class Derived : Base
    {
        public override void M(string text = "derived-default")
        {
            Console.WriteLine("Derived.M: {0}", text);
        }
        
        public void RunTests()
        {
            M();      // Prints Derived.M: base-default
            this.M(); // Prints Derived.M: derived-default
            base.M(); // Prints Base.M: base-default
        }
    }
    
    class Test
    {
        static void Main()
        {
            Derived d = new Derived();
            d.RunTests();
        }
    }
                                             
