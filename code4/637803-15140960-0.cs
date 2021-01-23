    class Program
    {
        const int Dimension = 4;
    
        static void Main(string[] args)
        {
            char[] blocks = new char[Dimension];
            for (int j = 0; j < Dimension; j++)
                blocks[j] = ' ';
            
            for (int i = 0; i < Dimension; i++)
            {
                blocks[Dimension - i - 1] = '█';
    
                for (int j = 0; j < Dimension; j++)
                    Console.Write(blocks[j]);
    
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
