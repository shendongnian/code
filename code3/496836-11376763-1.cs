    class Program
    {
        public static void FooMethod()
        {
            Console.WriteLine("Called foo");
        }
        static void Main()
        {
            Action foo = FooMethod; // foo now references FooMethod()
            foo(); // outputs "Called foo"
        }
    }
