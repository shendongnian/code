    public Vector2 GetVectorToTile(int x, int y)
    {
        return new Vector2(x * TileWidth, y * TileHeight);
    }
    public Vector2 GetVectorToTile(Point start)
    {
        return GetVectorToTile(start.X, start.Y);
    }
