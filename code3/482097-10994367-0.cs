    public static class Extensions
    {
        public static void Times(this Int32 times, Action<Int32> action)
        {
            for (int i = 0; i < times; i++)
                action(i);
        }
    }
    class Program
    {
        delegate void Del();
        static void Main(string[] args)
        {
            5.Times(Console.WriteLine);
            // or
            5.Times(i => Console.WriteLine(i));
        }
    }
