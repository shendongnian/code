    private void DoSomethingWithNeighbours(int x, int y, int z)
    {
        foreach (var neighbout in this.GetNeighbours(x, y, z)
        {
            // ...
        }
    }
    private IEnumerable<Item> GetNeighbours(int x, int y, int z)
    {
        if (x > 0)
        {
            if (y > 0)
            {
                yield return myMap.Depth[z].Rows[x - 1].Columns[y - 1];
            }
            yield return myMap.Depth[z].Rows[x - 1].Columns[y];
            if (y < ColumnCount - 1)
            {
                yield return myMap.Depth[z].Rows[x - 1].Columns[y + 1];
            }
        }
        if (y > 0)
        {
            yield return myMap.Depth[z].Rows[x].Columns[y - 1];
        }
        if (y < ColumnCount - 1)
        {
            yield return myMap.Depth[z].Rows[x].Columns[y + 1];
        }
        if (x < RowCount - 1)
        {
            if (y > 0)
            {
                yield return myMap.Depth[z].Rows[x + 1].Columns[y - 1];
            }
            yield return myMap.Depth[z].Rows[x + 1].Columns[y];
            if (y < ColumnCount - 1)
            {
                yield return myMap.Depth[z].Rows[x + 1].Columns[y + 1];
            }
        }
    }
