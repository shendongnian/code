    using System;
    using System.Reflection;
    
    namespace Foo.Bar
    {
        public class SomeTypeContainingYourFunction
        {
            public string MyFunction(int foo, string bar, bool baz)
            {
                return string.Format("foo: {0}, bar: {1}, baz: {2}", foo, bar, baz);
            }
        }
    }
    namespace Bazinga
    {
        class Program
        {
            static void Main()
            {
                string strFunctionName = "MyFunction";
                Type t = Type.GetType("Foo.Bar.SomeTypeContainingYourFunction");
                var instance = Activator.CreateInstance(t);
                var arguments = new object[] { 1, "foo", false };
                var result = t.InvokeMember(
                    strFunctionName, 
                    BindingFlags.InvokeMethod, 
                    null, 
                    instance, 
                    arguments
                );
                Console.WriteLine(result);
            }
        }
    }
