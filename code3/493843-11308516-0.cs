    namespace test
    {
        public class testHelper
        {
            public static void fooByVal(int i)
            {
                test.foo(i);
            }
            public static void fooByRef(ref int i)
            {
                test.foo(ref i);
            }
        }
    }
