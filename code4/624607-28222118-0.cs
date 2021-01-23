    class Base<T>
    {
        public static int Counter { get; set; }
        public Base()
        {
        }
    }
    class DerivedA : Base<DerivedA>
    {
        public DerivedA()
        {
        }
    }
    class DerivedB : Base<DerivedB>
    {
        public DerivedB()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DerivedA.Counter = 4;
            DerivedB.Counter = 7;
            Console.WriteLine(DerivedA.Counter.ToString()); // Prints 4
            Console.WriteLine(DerivedB.Counter.ToString()); // Prints 7
            Console.ReadLine();
        }
    }
