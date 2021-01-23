    public Vector2 GetMouseTilePosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(IsMouseInsideTile(x, y))
                {
                    return new Vector2(x, y);
                }
            }
        }
        return new Vector2(-1, -1);
    }
    
    public bool IsMouseInsideTile(int x, int y)
    {
        MouseState MS = Mouse.GetState();
        return (MS.X >= x * 64 && MS.X <= (x + 1) * 64 &&
            MS.Y >= y * 64 && MS.Y <= (y + 1) * 64);
    }
