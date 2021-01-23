    using System;
    using System.Collections.Generic;
    public class Program
    {
        public string Bar { get; set; }
    
        static void Main()
        {
            var foo = new Foo();
            FooUtils.Execute(foo, "B");
            FooUtils.Execute(foo, "D");
        }
    }
    static class FooUtils
    {
        public static void Execute(Foo foo, string methodName)
        {
            methodCache[methodName](foo);
        }
        static readonly Dictionary<string, Action<T>> methodCache;
        static FooUtils()
        {
            methodCache = new Dictionary<string, Action<T>>();
            foreach (var method in typeof(T).GetMethods())
            {
                if (!method.IsStatic && method.ReturnType == typeof(void)
                    && method.GetParameters().Length == 0)
                {
                    methodCache.Add(method.Name, (Action<T>)
                        Delegate.CreateDelegate(typeof(Action<T>), method));
                }
            }
        }
    }
    
    public class Foo
    {
        public void A() { Console.WriteLine("A"); }
        public void B() { Console.WriteLine("B"); }
        public void C() { Console.WriteLine("C"); }
        public void D() { Console.WriteLine("D"); }
        public string Ignored(int a) { return ""; }
    }
