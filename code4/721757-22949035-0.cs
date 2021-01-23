    // Main.cs
    using System;
    namespace TestCon
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo foo = new Foo();
                Console.WriteLine(Convert.ToString(123));
                Console.WriteLine(Convert.ToInt32("234"));
            }
        }
    }
    //Foo.cs (note that there are no using statements in this file)
    namespace TestCon
    {
        class Foo
        {
           public Foo()
           { }
        }  
    }
