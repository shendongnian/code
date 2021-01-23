    for (int x = 0; x < grid.Count; x++)
        {
            for (int y = 0; y < grid[x].Count; y++)
            {
                if (grid[x].Count > y && grid[x][y] == grid[x][y + 1])
                {
                    if (!shapesToDestroy.Contains(grid[x][y]))
                    {
                        shapesToDestroy.Add(grid[x][y]);
                    }
                    if (!shapesToDestroy.Contains(grid[x][y + 1]))
                    {
                        shapesToDestroy.Add(grid[x][y + 1]);
                    }
                }
                if (grid.Count > x && grid[x+1].Count > y && grid[x][y] == grid[x + 1][y])
                {
                    if (!shapesToDestroy.Contains(grid[x][y]))
                    {
                        shapesToDestroy.Add(grid[x][y]);
                    }
                    if (!shapesToDestroy.Contains(grid[x + 1][y]))
                    {
                        shapesToDestroy.Add(grid[x + 1][y]);
                    }
                }
            }
        }
