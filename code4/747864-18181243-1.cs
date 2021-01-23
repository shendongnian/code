    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = Enumerable.Range(0, 10).ToList();
            test = test.ShiftLeft(1);
            PrintList(test);
            Console.WriteLine("");
            PrintList(test.ShiftRight(2));
            Console.ReadLine();
        }
        private static void PrintList(List<int> test)
        {
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i]);
            }
        }
    }
