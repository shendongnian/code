    public void Draw(SpriteBatch spriteBatch)
            {
    	for (int row = 0; row < tileMap.GetLength(1); row++) {
    		for (int col = 0; col < tileMap.GetLength(0); col++)
    			{
                        	spriteBatch.Draw(_texture, new Rectangle(row * _tW, col * _tH, _tW, _tH), new Rectangle(tileMap[row, col] * _tW, tileMap[row, col] * _tH, _tW, _tH), Color.White);
    			}
    		}
            }
