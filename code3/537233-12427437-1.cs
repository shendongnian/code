    public static void UpdateAll(this MyType[,] grid, Func<MyType,MyType> action)
    {
        for (int row = grid.GetLowerBound(0); row <= grid.GetUpperBound(0); row++)
            for (int col = grid.GetLowerBound(1); col <= grid.GetUpperBound(1); col++)
                grid[row, col] = action(grid[row, col]);
    }
