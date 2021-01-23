    int y = startPointY;
    int x = startPointX;
    int switchAt = items.Count/2; //<--- or where ever you might want to break up the strings
    int max = 0;
    for(int i = 0; i < items.Count; i++)
    {
        spriteBatch.DrawString(font, items[i], new Vector2(x, y), Color);
        if(max < spriteFont.MeasureString(items[i]))
        {
            //this is to make sure the next column of strings are aligned
            max = spriteFont.MeasureString(items[i]);
        }
        y += someYSpace;
        if(i == switchAt)
        {
             x += max + someXSpace;//someXSpace not neccessary
             y = startPointY;         
        }         
    }
