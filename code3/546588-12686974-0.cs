    using System;
    
    class Test
    {
        static void Main()
        {
            CallThrow();
        }
        
        static void CallThrow()
        {
            Throw();
        }
        
        static void Throw()
        {
            // Add a condition to try to disuade the JIT
            // compiler from inlining *this* method. Could
            // do this with attributes...
            if (DateTime.Today.Year > 1000)
            {
                throw new Exception();
            }
        }
    }
