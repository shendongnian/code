        static string DontMessWithStrings = "this is a test";
        static void Main(string[] args) {
            string s = "this is a test";
            UnsafeReverse(s);
            Console.WriteLine(DontMessWithStrings);
        }
