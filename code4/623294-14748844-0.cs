    class C<V>
    {
        static int count = 0;
        public C()
        {
            count++;
        }
        public static int Count
        {
            get { return count; }
        }
    }
    class Application
    {
        static void Main()
        {
            C<int> x1 = new C<int>();
            Console.WriteLine(C<int>.Count);  // Prints 1 
            C<double> x2 = new C<double>();
            Console.WriteLine(C<double>.Count); // Prints 1 
            Console.WriteLine(C<int>.Count);  // Prints 1 
            C<int> x3 = new C<int>();
            Console.WriteLine(C<int>.Count);  // Prints 2 
        }
    }
