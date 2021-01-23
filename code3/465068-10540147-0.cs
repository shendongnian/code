    using System;
    using System.Linq.Expressions;
    
    class Test
    {
        static void Main()
        {
            var left = Expression.Constant("1", typeof(string));
            var right = Expression.Constant("2", typeof(string));
            var compare = Expression.Call(typeof(string),
                                          "Compare",
                                          null,
                                          new[] { left, right });
            var compiled = Expression.Lambda<Func<int>>(compare).Compile();
            Console.WriteLine(compiled());
        }
    }
