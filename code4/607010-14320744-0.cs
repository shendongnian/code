    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public static class Program
        {
            public static void Main()
            {
                Foo foo = new Foo();
                String[] names = new String[] { "Hello" };
                Console.WriteLine(String.Join(", ", names.Select(name => foo.GetName(name))))
            }
        }
    
        public class Foo { }
    
        public static class Extensions
        {
            public static String GetName(this Foo foo, String name)
            {
                return name;
            }
        }
    }
