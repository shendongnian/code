    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        class MainApp
        {
            static void Main()
            {
                var registry = new Dictionary<Type, Func<Exception, bool>>();
    
                registry.Add(typeof(ArgumentException), HandleArgumentException);
    
                bool result = registry[typeof(ArgumentException)].Invoke(new ArgumentException());
            }
    
            public static bool HandleArgumentException(Exception exception)
            {
                ArgumentException ex = (ArgumentException)exception;
    
                // some logic
    
                return true;
            }
        }
    }
