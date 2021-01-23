    class Program
    {
        static void Main(string[] args)
        {
            Test<int>.i = 2;
            Test<string>.i = 8;
            Console.WriteLine(Test<int>.i);   // would write "8" if the fields were shared
            Console.WriteLine(Test<string>.i);
            // Console.WriteLine(Test.i); // does not compile
            // Console.WriteLine(Test<>.i); // does not compile
        }
    }
    class Test<T>
    {
        public static int i;
    }
