    public bool IsMouseInsideTile(int x, int y)
    {
        MouseState MS = Mouse.GetState();
        return (MS.X >= x * 64 && MS.X <= (x + 1) * 64 &&
            MS.Y >= y * 64 && MS.Y <= (y + 1) * 64);
    }
