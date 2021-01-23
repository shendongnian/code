    using System;
    
    namespace Scratch
    {
        class Scratch
        {
            public static void Main()
        {
            var x = 2;
            switch (x)
            {
                case 1:
                {
                    var foo = "one";
                    Console.Out.WriteLine(foo);
                    break;
                }
                case 2:
                {
                    foo = "two"; // is foo in scope here?
                    Console.Out.WriteLine(foo);
                    break;
                }
            }
        }
    }
