    public void GetMouseTilePosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(IsMouseInsideTile(x, y))
                {
                    //Do something to tile [x, y], like displaying a hover image or something
                }
            }
        }
    }
    
    public bool IsMouseInsideTile(int x, int y)
    {
        MouseState MS = Mouse.GetState();
        return (MS.X >= x * 64 && MS.X <= (x + 1) * 64 &&
            MS.Y >= y * 64 && MS.Y <= (y + 1) * 64);
    }
