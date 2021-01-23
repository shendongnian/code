            Color color;
            int linePadding = 3;
            int switchAt = buttonList.Count / 2 - 1;//minus one because the list starts at 0, and goes up to 3, so 1 is the switch point
            else
            {
                spriteBatch.Draw(mMenuPhoto, new Rectangle(800, 150, mMenuPhoto.Width, mMenuPhoto.Height), Color.White);  
                float X = 210;
                float Y = 600 - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding));
                float max = 0;
                float linesXSpace = 30;//to seperate this lines to make room for '|'
                for (int i = 0; i < buttonList.Count; i++)
                {
                    color = (i == selected) ? Color.LightGray : Color.DarkSlateGray;
                    if (max < spriteFont.MeasureString(buttonList[i]).X)
                    {
                        max = spriteFont.MeasureString(buttonList[i]).X;
                    }
                    if (i != selected)
                    {
                        spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2(X, Y), color);
                        Y += spriteFont.MeasureString(buttonList[i]).Y;    
                        if (i == switchAt)
                        {
                            X += max + linesXSpace;
                            Y = 600 - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding));
                        }                       
                       
                    }
                    else
                    {     
                        spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2(X, Y), color);
                        spriteBatch.DrawString(spriteFont2, "|", new Vector2(X - 20, Y), Color.DarkGreen);
                        Y += spriteFont.MeasureString(buttonList[i]).Y;   
                        if (i == switchAt)
                        {
                            X += max + linesXSpace;
                            Y = 600 - (spriteFont.LineSpacing * (buttonList.Count) / 2) + ((spriteFont.LineSpacing + linePadding) * i);
                        }                                             
                    }
                }
            }
