    static void Main(string[] args)
    {
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Console.Write("{0}\t", (i == 0) ? i : i * j);
            }
            Console.WriteLine();
        }
    
        Console.ReadLine();
    }
