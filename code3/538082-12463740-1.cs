    class DerivedClass : ParentClass
    {
         public DerivedClass()
         {
             Console.WriteLine("Derived class constructor!");
         }
    }
     class ParentClass
    {
         public ParentClass()
         {
             System.Console.WriteLine("Parent class constructor!");
         }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var a = new DerivedClass(); //Implicitly Typed local variables.
        }
    }
