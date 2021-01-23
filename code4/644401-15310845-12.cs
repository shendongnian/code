    private static void PrintMatrix(ref int?[,] matrix, int Count)
    {
        Console.Write("       ");
        for (int i = 0; i < Count; i++)
        {
            Console.Write("{0}  ", (char)('A' + i));
        }
        Console.WriteLine();
        for (int i = 0; i < Count; i++)
        {
            Console.Write("{0} | [ ", (char)('A' + i));
            for (int j = 0; j < Count; j++)
            {
                if (i == j)
                {
                    Console.Write(" &,");
                }
                else if (matrix[i, j] == null)
                {
                    Console.Write(" .,");
                }
                else
                {
                    Console.Write(" {0},", matrix[i, j]);
                }
            }
            Console.Write(" ]\r\n");
        }
        Console.Write("\r\n");
    }
