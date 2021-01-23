    /**CODE**/
        public static void Main(string[] args)
        {
            B c = new C();
            Test(c);
            Console.ReadKey();
        }
        public static void Test(A a) { Console.WriteLine(typeof(A).ToString()); }
        public static void Test(B b) { Console.WriteLine(typeof(B).ToString()); }
        public static void Test(C c) { Console.WriteLine(typeof(C).ToString()); }
    /**OUTPUT**/
        StackOverflow.Demos.B
