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
            var genericType = typeof(MyClass<>).MakeGenericType(new[] { type });
            MethodInfo genericTypeMyMethodInfo = genericType.GetMethod("MyMethod");
            return genericTypeMyMethodInfo;
        }
        public static void Test1()
        {
            Resolve(typeof(string)).Invoke(new MyClass<string>(), new object[] { "Hello, World!" });
        }
        // fully type agnostic test
        public static void Test2()
        {
            TestInvoke(typeof(string), new MyClass<string>(), new object[] { "Hello, World!" });
        }
        public static void TestInvoke(Type argType, object myclass, params object[] arguments)
        {
            // you could also construct a 'MyClass<>' based on the type, to make it further dynamic
            Resolve(argType).Invoke(myclass, arguments);
        }
    }
