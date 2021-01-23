    int rowSize = 8;
    int colSize = 8;
    for (int row = 0; row < rowSize; row++)
    {
        for (int col = 0; col < colSize; col++)
        {
            if ((row + col) % 2 == 0)
                {
                Console.WriteLine("X");
                }
            else
                {
                Console.writeLine("O");
                }
        }
        Console.WriteLine();
    }
