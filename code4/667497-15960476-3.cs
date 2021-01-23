    public class MyClass<T>
    {
        public void MyMethod(T arg, bool flag)
        {
            Console.WriteLine("type: MyClass<{0}>, arg: {1}, flag:{2}", typeof(T), 
                arg.ToString(), flag);
        }
        public void MyMethod(T arg)
        {
            Console.WriteLine("type: MyClass<{0}>, arg: {1}", typeof(T), arg.ToString());
        }
    }
    public class GenericInvokeTest
    {
        static MethodInfo Resolve(Type type)
        {
            var name = ActionName<object>(x => (o) => x.MyMethod(o));
            var genericType = typeof(MyClass<>).MakeGenericType(new[] { type });
            MethodInfo genericTypeMyMethodInfo = genericType.GetMethod(name); // "MyMethod");
            genericTypeMyMethodInfo = genericType.GetMethod(name, new[] { type, typeof(bool) });
            return genericTypeMyMethodInfo;
        }
        public static void Test1()
        {
            Resolve(typeof(string))
                .Invoke(new MyClass<string>(), new object[] { "Hello, World!", true });
            // Resolve(typeof(string))
                .Invoke(new MyClass<string>(), new object[] { "Hello, World!" });
        }
    }
