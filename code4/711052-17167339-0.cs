     using System;
        using System.Reflection;
        namespace ConsoleApplication1
        {
            public class StaticInvoke
            {
                private static void Main()
                {
                    MethodInfo info = typeof(StaticInvoke).GetMethod("SampleMethod", BindingFlags.Public | BindingFlags.Static);
                    var input = new object[] {"inputValue"};
                    var value = info.Invoke(null, input);
                    Console.WriteLine(value);
                    Console.WriteLine(input[0]);
                    Console.ReadLine();
                }
        
                public static bool SampleMethod(out string input)
                {
                    input = "modified val";
                    Console.WriteLine("I am executing");
                    return true;
                }
            }
        }
