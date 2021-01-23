    public IEnumerable<Point> GetLocations(int numCols,int colWidth,int rowHeight)
    {
        int x = 0, y = 0;
        while (true)
        {
            for (int i = 0; i < numCols; i++)
            {
                yield return new Point(x, y);
                x += colWidth;
            }
            x = 0;
            y += rowHeight;
        }
    }
