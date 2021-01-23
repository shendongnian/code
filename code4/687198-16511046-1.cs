    //In your menu class
    public void Draw(SpriteBatch spriteBatch)
    {
        Color color;
        int linePadding = 3;
       
       
        if (gameTime.TotalGameTime.TotalSeconds <= 3)
        { 
            mBatch.Begin();
            mBatch.Draw(mTheQuantumBros2, new Rectangle(300, 150, mTheQuantumBros2.Width, mTheQuantumBros2.Height), Color.White);
            mBatch.End(); 
        }
        else
        {
                      
            for (int i = 0; i < buttonList.Count; i++)
            {
                color = (i == selected) ? Color.LawnGreen : Color.Gold;
                spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((Game1.screen.Width / 2) - (spriteFont.MeasureString(buttonList[i]).X / 2), (Game1.screen.Height / 2) - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
            }
        }
    }
