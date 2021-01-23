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
            PropertyInfo property = p.GetType().GetProperty("ModifiedOn");
            PropertyInfo goodProperty = property.DeclaringType.GetProperty("ModifiedOn");
            goodProperty.SetValue(p, DateTime.Today, null);
            Console.WriteLine(p.ModifiedOn);
        }
    }
