    static class Class1
    {
        static bool IsFromTest = false;
        static Class1()
        {
            SetIsFromTest();
        }
        [Conditional("TESTPROJECT")]
        public static void SetIsFromTest()
        {
            IsFromTest = true;
        }
