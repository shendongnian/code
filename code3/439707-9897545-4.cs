    public void Draw(SpriteBatch spriteBatch)
    {
        for(int x = 0; x < 10; x++) 
        {
            for (int y = 0; y < 10; y++)
            {
                spriteBatch.Draw(tiles[index[x, y]], tileRect = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), 
                                 Color.White);
            }
        }
        // draw selection
        Vector2 screenXY = TileToScreen(mSelectedTileCoordinate);
        Rectangle drawArea = new Rectangle(screenXY.X, screenXY.Y, tileWidth, tileHeight);
        spriteBatch.Draw(mBlackTile, drawArea, Color.White);
    }
    private Vector2 TileToScreen(Vector2 pTileXY)
    {
       // this does the reverse of ScreenToTile
              
       Vector2 tileSize = GetTileSize();
       Vector2 mapXY = pTileXY * tileSize;       
       Vector2 mapOffset = GetMapOffset();
       // you'll have to do this the opposite way from ScreenToTile()
       Vector2 screenXY = mapXY +/- mapOffset;       
       
       return screenXY;
    }
