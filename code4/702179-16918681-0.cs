    static class MyExtensions
    {
        public static void Foo(this int i)
        {
            // do something
        }
    }
    var methodInfo = typeof(MyExtensions).GetMethod("Foo");
    methodInfo.Invoke(null, new object[] { 1 });
