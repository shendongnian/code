    public class Test
    {
        public static void Main()
        {
            var t = new Test();
            CheckMethodAttributes<Action>(t.Test1);
            CheckMethodAttributes<Action<int>>(t.Test2);
            CheckMethodAttributes<Action<object, string, bool>>(t.Test3);
        }
        public void Test1() { }
        public void Test2(int a) { }
        public void Test3(object a, string c, bool d) { }
        public static void CheckMethodAttributes<T>(T func)
        {
            MethodInfo method = new MethodOf<T>(func);
            // Example attribute check:
            var ignoreAttribute = method.GetAttribute<IgnoreAttribute>();
            if (ignoreAttribute != null)
            {
                // Do something here...
            }
        }
    }
