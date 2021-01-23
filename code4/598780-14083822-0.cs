    using System;
    
    class Base
    {
        public Base()
        {
            Console.WriteLine(ToString());
        }
    }
    
    class Derived : Base
    {
        private int x = 5;
        private int y;
        
        public Derived()
        {
            y = 5;
        }
        
        public override string ToString()
        {
            return string.Format("x={0}, y={1}", x, y);
        }
    }
    
    class Test
    {
        static void Main()
        {
            // Prints x=5, y=0
            new Derived();
        }
    }
