    using System;
    
    namespace DesignPatterns
    {
        public sealed class Singleton
        {
            private static volatile Singleton instance = null;
    
            private Singleton() { }
    
            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                       Interlocked.CompareExchange(ref instance, new Singleton(), null);
    
                    return instance;
                }
            }
        }
    }
