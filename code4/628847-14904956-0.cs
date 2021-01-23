    using System;
    
    class Foo
    {
        private readonly string name;
        
        public Foo(string name)
        {
            this.name = name;
        }
        
        public static explicit operator string(Foo input)
        {
            return input.name;
        }
    }
    
    class Test
    {
        static void Main()
        {
            dynamic foo = new Foo("name");
            Console.WriteLine("Casting: {0}", (string) foo);
            Console.WriteLine("As: {0}", foo as string);
        }
    }
