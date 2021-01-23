    using System;
    namespace Stackoverflow
    {
        class Program
        {
            public static T SomeNewMethod<T>()
                where T : new()
            {
                return new T();
            }
    
            public static T SomeDefaultMethod<T>()
                where T : new()
            {
                return default(T);
            }
    
            struct MyStruct { }
    
            class MyClass { }
    
            static void Main(string[] args)
            {
                RunWithNew();
                RunWithDefault();
            }
    
            private static void RunWithDefault()
            {
                MyStruct s = SomeDefaultMethod<MyStruct>();
                MyClass c = SomeDefaultMethod<MyClass>();
                int i = SomeDefaultMethod<int>();
                bool b = SomeDefaultMethod<bool>();
    
                Console.WriteLine("Default");
                Output(s, c, i, b);
            }
    
            private static void RunWithNew()
            {
                MyStruct s = SomeNewMethod<MyStruct>();
                MyClass c = SomeNewMethod<MyClass>();
                int i = SomeNewMethod<int>();
                bool b = SomeNewMethod<bool>();
    
                Console.WriteLine("New");
                Output(s, c, i, b);
            }
    
            private static void Output(MyStruct s, MyClass c, int i, bool b)
            {
                Console.WriteLine("s: " + s);
                Console.WriteLine("c: " + c);
                Console.WriteLine("i: " + i);
                Console.WriteLine("b: " + b);
            }
    
        }
    }
