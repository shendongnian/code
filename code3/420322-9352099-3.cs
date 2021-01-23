    // Consider declaring these as constants outside the method
    int rowCount = 10;
    int columnCount = 15;
    int[][] values = new int[rowCount];
    Random random = new Random();
    for (int row = 0; row < rowCount; row++)
    {
        values[row] = new int[columnCount];
        for (int column = 0; column < columnCount; column++)
        {
            values[row][column] = random.Next(100);
        }
    }
