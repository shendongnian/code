    using System;
    using System.Reflection.Emit;
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                var constructor = typeof(Foo).GetConstructor(Type.EmptyTypes);
                var helperMethod = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(Foo) }, typeof(Foo).Module);
                var ilGenerator = helperMethod.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Call, constructor);
                ilGenerator.Emit(OpCodes.Ret);
                var constructorInvoker = (Action<Foo>)helperMethod.CreateDelegate(typeof(Action<Foo>));
                var foo = new Foo();
                constructorInvoker(foo);
                constructorInvoker(foo);
            }
        }
        class Foo
        {
            int x;
            public Foo()
            {
                Console.WriteLine("Constructor Foo() called, GetHashCode() returns {0}", GetHashCode(), x);
                x++;
            }
        }
    }
