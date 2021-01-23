    class Program
    {
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                string s = Console.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    Debug.WriteLine(s);
                    Console.WriteLine(s);
                }
            }
        }
    }
