    using System;
    using System.Reflection;
    namespace SomeNs
    {
        public abstract class Foo
        {
    
        }
    }
    
    public class Program
    {
        static void Main()
        {
            var asm = Assembly.GetExecutingAssembly();
            var type = asm.GetType("SomeNs.Foo", true);
            Console.WriteLine(type);
        }
    }
