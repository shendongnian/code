    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            InvokeGenericMethod(typeof(string));
            InvokeGenericMethod(typeof(int));
        }
        
        static void InvokeGenericMethod(Type type)
        {
            var method = typeof(Test).GetMethod("GenericMethod");
            var generic = method.MakeGenericMethod(type);
            generic.Invoke(null, null);
        }
        
        public static void GenericMethod<T>()
        {
            Console.WriteLine("typeof(T) = {0}", typeof(T));
        }    
    }
