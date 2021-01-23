    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
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
    
                private bool Invoke<T>(T exception) where T : Exception
                {
                    return Get<T>().Invoke(exception);
                }
    
                public bool Invoke(Exception exception)
                {
                    MethodInfo method = this.GetType().GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo generic = method.MakeGenericMethod(exception.GetType());
                    var result = generic.Invoke(this, new object[] { exception });
    
                    return (bool)result;
                }
    
                public void Add<T>(Func<T, bool> handler) where T : Exception
                {
                    registry.Add(typeof(T), handler);
                }
    
            }
    
            static void Main()
            {
                ExceptionRegistry registry = new ExceptionRegistry();
    
                registry.Add<ArgumentException>((ArgumentException exception) =>
                    {
                        // some logic
    
                        return true;
                    });
    
                Exception ex = new ArgumentException();
    
                bool result = registry.Invoke(ex);
            }
        }
    }
