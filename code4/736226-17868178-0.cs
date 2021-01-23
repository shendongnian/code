    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = new List<int> { 3 };
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(numList[i]);
                numList.Add(numList[i] + 5);
            }
            Console.Read();
        }
    }
