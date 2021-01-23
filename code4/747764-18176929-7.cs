    public int GetXY(int x, int y)
    {
        if (x < 0 || x >= grid.Length)
        {
            throw ...
        }
        int[] items = grid[x];
        if (y < 0 || y >= items.Length)
        {
            throw ...
        }
        return items[y];
    }
