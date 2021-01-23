    class Program
        {
            static void Main(string[] args)
            {
                StaticClass.x = 89;
                Console.WriteLine(StaticClass.x);
                changeValue(StaticClass.x);
                Console.WriteLine(StaticClass.x);
                Console.ReadKey();
            }
            static void changeValue(int x)
            {
                x = x + 1;
            }
        }
    {
        public static class StaticClass
        {
            public static int x { get; set; }
        }
    }
