    public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                        spriteBatch.Draw(tiles[index[x,y]].texture, tileRect = new Rectangle(x * 64, y * 64, 64, 64), 
                            Color.White);
                        Vector2 mouseCoord = GetMouseTilePosition();
                        if(mouseCoord.X > 0)
                            spriteBatch.Draw(selected.texture, tileRect = new Rectangle((int)mouseCoord.X * 64, (int)mouseCoord.Y * 64, 64, 64), 
                                            Color.White);
                }
            }  
        }
