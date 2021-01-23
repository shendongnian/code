    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    class Test
    {
        public static void Main()
        {
            Expression<Func<List<string>, string>> expression = list => list[0];
            Console.WriteLine(expression);
        }
    }
