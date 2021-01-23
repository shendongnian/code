    for (int i = 0; i < buttonList.Count; i++)
    {
         color = (i == selected) ? Color.LawnGreen : Color.Gold;
         if(i != selected)
         {
             spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((screenWidth / 2) /*- (spriteFont.MeasureString(buttonList[i]).X / 2)*/, (screenHeight / 2) - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
         }
         else
         {
             spriteBatch.DrawString(spriteFont,"|" + buttonList[i] + "|", new Vector2((screenWidth / 2) - (int)spriteFont.MeasureString("|").X, (screenHeight / 2) - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
         }
    }
