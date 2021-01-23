    public Vector2 GetVectorToTile(int? x = null, int? y = null, Point? start = null)  
    {
        Vector2 vector = null;
        if (x.HasValue && y.HasValue)
        {
            vector = new Vector2(x * TileWidth, y * TileHeight);         
        }
        else if(start.HasValue)
        {
            vector = new Vector2(start.X * TileWidth, start.Y * TileHeight); 
        }
        return vector;
    }
