    public static class ClassA
    {
        private static void sharedMethod<T>() { }
        public static void ClassMethod()
        {
            sharedMethod<object>();
        }
    }
    public static class GenericClass<T>
    {
        static MethodInfo sharedMethodInfo;
        static GenericClass()
        {
            MethodInfo mi = typeof(ClassA).GetMethod("sharedMethod", BindingFlags.NonPublic | BindingFlags.Static);
            sharedMethodInfo = mi.MakeGenericMethod(new Type[] { typeof(T) });
        }
        public static void GenericClassMethod()
        {
            sharedMethodInfo.Invoke(null, null);
        }
    }
