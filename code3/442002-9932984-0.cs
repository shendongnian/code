    public void Draw(SpriteBatch spriteBatch)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (IsMouseInsideTile(x, y))
                {
                    spriteBatch.Draw(selection, tileRect = new Rectangle(x * 64, y * 64, 64, 64),
                                        Color.White);
                }
                spriteBatch.Draw(tiles[index[x,y]].texture, tileRect = new Rectangle(x * 64, y * 64, 64, 64), 
                        Color.White);          
            }
        }  
    }
