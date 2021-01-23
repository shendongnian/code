    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        class MainApp
        {
            public class ExceptionRegistry
            {
                Dictionary<Type, object> registry = new Dictionary<Type, object>();
    
                private Func<T, bool> Get<T>() where T : Exception
                {
                    return registry[typeof(T)] as Func<T, bool>;
                }
    
                public bool Invoke<T>(T exception) where T: Exception
                {
                    return Get<T>().Invoke(exception);
                }
    
                public void Add<T>(Func<T, bool> handler) where T : Exception
                {
                    registry.Add(typeof(T), handler);
                }
    
            }
    
            static void Main()
            {
                ExceptionRegistry registry = new ExceptionRegistry();
    
                registry.Add<ArgumentException>( (ArgumentException exception) =>
                    {
                        // some logic
    
                        return true;
                    });
    
                bool result = registry.Invoke<ArgumentException>(new ArgumentException());
            }
        }
    }
