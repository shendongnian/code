    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace ConsoleApp {
        public class MyClass {
            private int privateInt = 6;
        }
        
        internal static class Program {
            private delegate ref TReturn OneParameter<TReturn, in TParameter0>(TParameter0 p0);
    
            private static void Main() {
                var myClass = new MyClass();
    
                var method = new DynamicMethod(
                    "methodName",
                    typeof(int).MakeByRefType(), // <- MakeByRefType() here
                    new[] {typeof(MyClass)}, 
                    typeof(MyClass), 
                    true); // skip visibility
    
    
                const BindingFlags bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    
                var il = method.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldflda, typeof(MyClass).GetField("privateInt", bindings));
                il.Emit(OpCodes.Ret);
    
                var invokeSquareIt = (OneParameter<int, MyClass>) method.CreateDelegate(typeof(OneParameter<int, MyClass>));
    
                Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
                Console.WriteLine(invokeSquareIt(myClass));
            }
        }
    }
