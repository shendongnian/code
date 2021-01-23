    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                var constructor = typeof(Foo).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                var helperMethod = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(Foo) }, typeof(Foo).Module, true);
                var ilGenerator = helperMethod.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Call, constructor);
                ilGenerator.Emit(OpCodes.Ret);
                var constructorInvoker = (Action<Foo>)helperMethod.CreateDelegate(typeof(Action<Foo>));
                var foo = Foo.Create();
                constructorInvoker(foo);
                constructorInvoker(foo);
            }
        }
        class Foo
        {
            int x;
            public static Foo Create()
            {
                return new Foo();
            }
            private Foo()
            {
                Console.WriteLine("Constructor Foo() called, GetHashCode() returns {0}, x is {1}", GetHashCode(), x);
                x++;
            }
        }   
    }
