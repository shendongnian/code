    int numberAt(int row, int col)
    {
        return numbers[row * totalColumns + col];
    }
    int[] colTotals = new int[totalColumns];
    int[] rowTotals = new int[totalRows];
    for (int row = 0; row < totalRows; ++row)
    {
        for (int col = 0; col < totalColumns; ++col)
        {
            int number = numberAt(row, col);
            rowTotals[row] += number; 
            colTotals[col] += number;
        }
    }
