    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    class Foo
    {
        public readonly int i;
        public int I { get { return i; } }
        public Foo(int i) { this.i = i; }
    }
    static class Program
    {
        static void Main()
        {
            var setter = CreateWriteAnyInt32Field(typeof(Foo), "i");
            var foo = new Foo(123);
            setter(foo, 42);
            Console.WriteLine(foo.I); // 42;
        }
        static Action<object, int> CreateWriteAnyInt32Field(Type type, string fieldName)
        {
            var field = type.GetField(fieldName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var method = new DynamicMethod("evil", null,
                new[] { typeof(object), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, type);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, field);
            il.Emit(OpCodes.Ret);
            return (Action<object, int>)method.CreateDelegate(typeof(Action<object, int>));
        }
    }
