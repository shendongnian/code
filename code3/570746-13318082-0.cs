    using System;
    using System.Reflection;
    namespace StackOverflow.Demos
    {
        class Program
        {
            public static void Main(string[] args) 
            {
                //RuntimeMethodHandle handle = typeof(object).GetMethod("TestMe").MethodHandle; //throws error
                RuntimeMethodHandle handle = typeof(object).GetMethod("ToString").MethodHandle; //returns System.Object
                MethodBase mb = MethodInfo.GetMethodFromHandle(handle);
                Console.WriteLine(mb.DeclaringType);
                Console.ReadKey();
            }
        }
        public static class ObjectExtensions
        {
            public static string TestMe(this object o) { return o.ToString(); }
        }
    }
    
