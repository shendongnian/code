    public void Draw(SpriteBatch spriteBatch, Level level)
        {
            for (int row = 0; row < level.tileMap.GetLength(1); row++) {
                for (int col = 0; col < level.tileMap.GetLength(0); col++) {
                    level.tileMap[col, row].Draw(spriteBatch);;
                }
                       
            }
        }
