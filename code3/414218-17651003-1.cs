    extern alias destination;
    namespace Test
    {
        public static class TestClass
        {
            public static void Success()
            {
                var foo = destination::Some.Duplicate.Namespace.SomeDuplicateType();
                var bar = Some.Duplicate.Namespace.SomeDuplicateType();
            }
        }
    }
