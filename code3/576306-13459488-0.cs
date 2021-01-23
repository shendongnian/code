    using System;
    using System.Collections.Generic;
    
    public class Test 
    {
        static void Main() 
        {
            IEnumerable<int> foo = Foo();
            Console.WriteLine(foo is IDisposable); // Prints True
        }
        
        static IEnumerable<int> Foo()
        {
            yield break;
        }
    }
