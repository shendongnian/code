    using System;
    class Test
    {
        public DateTime ModifiedOn { get; private set;}
    }
    
    class Derived : Test
    {
    }
    
    static class Program
    {
        static void Main()
        {
            Derived p = new Derived ();
            typeof(Test).GetProperty("ModifiedOn").SetValue(
                p, DateTime.Today, null);
            Console.WriteLine(p.ModifiedOn);
        }
    }
