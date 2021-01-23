    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                dynamic o = CreateGeneric(typeof(List<>), typeof(int));
                o.Add(1);
                Console.WriteLine(o[0]);
                Console.Read();
            }
    
            public static object CreateGeneric(Type generic, Type innerType, params object[] args)
            {
                System.Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
                return Activator.CreateInstance(specificType, args);
            }
        }
    }
