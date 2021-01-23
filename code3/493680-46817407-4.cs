    static void Main(string[] args)
    {
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                if (i == 0)
                {
                    Console.Write("{0}\t", i);
                }
                else
                {
                    Console.Write("{0}\t", i * j);
                }
            }
            Console.WriteLine();
        }
    
        Console.ReadLine();
    }
