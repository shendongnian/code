        private static void Perform<T>(T input) 
        {
            Console.WriteLine(typeof(T));
        }
        public static void Test<T>(T input) where T : class
        {
            Perform(input);
        }
        public static void Test<T>(T? input) where T : struct
        {
            Perform(input);
        }
        public static void Tester()
        {
            Test((int ?)2);
            Test(new object());
        }
