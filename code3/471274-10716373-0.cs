    class Test
    {
        protected static int var1;
        private static int var2;
    }
    class MainProgram : Test
    {
        private static int test;
        static void Main(string[] args)
        {
            Test.var1 = 2;
            Test.var2 = 5;   //ERROR :: We are not able to access var2 because it is private                 
        }
    }
