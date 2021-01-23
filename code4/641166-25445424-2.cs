    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LazySingleton
    {
        public class CLazySingleton
        {
            private static readonly Lazy<CLazySingleton> _instance
                = new Lazy<CLazySingleton>(() => new CLazySingleton());
            private static readonly object ThreadLock = new object();
            public static string abc;  
            //I will use the service connection object in place of 'abc' in the application
            //assume that 'abc' is storing the connection object    
    
            private CLazySingleton()
            { }
    
            public static CLazySingleton Instance
            {
                get
                {   
                    if (_instance.IsValueCreated)
                    {
                        return _instance.Value;
                    }
                    lock (ThreadLock)
                    {
                        if (abc == null)
                        {
                            abc = "Connection stored in this variable";
                            Console.WriteLine("Connection Made successfully");
                        }
                    }
                    return _instance.Value;
                }
            }
        }
    }
