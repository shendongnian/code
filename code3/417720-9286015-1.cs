    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            object o = new List<string>();
            Console.WriteLine(o is IEnumerable<object>);
        }
    }
