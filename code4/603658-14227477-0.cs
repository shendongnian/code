        static void Main(string[] args)
        {
            new[] { 1, 2, 3, 4 }.FirstOrDefault(j => j == Get());
            Console.ReadLine();
        }
        static int i = 5;
        static int Get()
        {
            Console.WriteLine("GET:" + i);
            return i--;
        }
