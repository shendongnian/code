    internal interface IF1
    {
        void M1();
    }
    internal interface IF2
    {
        void M2();
    }
    internal class ClassImplementingIF1IF2 : IF1, IF2
    {
        public void M1()
        {
            throw new NotImplementedException();
        }
        public void M2()
        {
            throw new NotImplementedException();
        }
    }
    internal static class Test
    {
        public static void doIT<T>(T t) where T:IF1,IF2
        {
            t.M1();
            t.M2();
        }
        public static void test()
        {
            var c = new ClassImplementingIF1IF2();
            doIT(c);
        }
    }
