    using System;
    using AluminumLua;
    public delegate void HelloDelegate();
    class Program
    {
        public static void Hello()
        {
            Console.Write("Hello world!");
        }
        static void Main()
        {
            var context = new LuaContext();
            var obj = LuaObject.FromDelegate(new HelloDelegate(Hello));
            context.SetGlobal("hello", obj);
            context.Get("hello").AsFunction().Invoke(new LuaObject[] { });
        }
    }
