    public class MyClass<T>
    {
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
            return genericTypeMyMethodInfo;
        }
        public static void Test1()
        {
            Resolve(typeof(string))
                .Invoke(new MyClass<string>(), new object[] { "Hello, World!" });
        }
    }
