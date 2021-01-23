    private void fill(int xInitial, int yInitial, Color border, Color c) 
    {
        var remaining = new Stack<Tuple<int, int>>();
        remaining.Push(Tuple.Create(xInitial, yInitial));
        
        while (remaining.Any())
        {
            var next = remaining.Pop();
            int x = next.Item1;
            int y = next.Item2;
            Color PointedColor = GetPixel(panel1, x, y);
            if (PointedColor.R != border.R && 
                PointedColor.G != border.G && 
                PointedColor.B != border.B &&
                PointedColor.R != c.R && 
                PointedColor.G != c.G && 
                PointedColor.B != c.B &&
                x >= 0 && 
                x < panel1.Size.Width && 
                y >= 0 && 
                y < panel1.Size.Height)
            {
                SetPixel(panel1, x, y, c);
                remaining.Push(Tuple.Create(x - 1, y));
                remaining.Push(Tuple.Create(x + 1, y));
                remaining.Push(Tuple.Create(x, y - 1));
                remaining.Push(Tuple.Create(x, y + 1));
            }
        }
    }
