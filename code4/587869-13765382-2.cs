    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    namespace StackOverflowExample
    {
        public static class DynamicObjectFactory
        {
            private static readonly object _lock = new object();
            public static object getInstance(string assemblyName, string className)
            {
                Monitor.Enter(_lock);
                try
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
                    return asm.CreateInstance(className, false, System.Reflection.BindingFlags.CreateInstance, null, null, null, null);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        public static object getInstance(string assemblyName, string className, object[] constructorParameters)
        {
            Monitor.Enter(_lock);
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
                return asm.CreateInstance(className, false, System.Reflection.BindingFlags.CreateInstance, null, constructorParameters, null, null);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
