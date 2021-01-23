    for(int i = 0; i < texturesToDraw.Count; i++)
    {
        if(i == selected) 
        {
             spriteBatch.Draw(texturesToDraw[i], position, Color.White)
        }
        else
        {
             spriteBatch.Draw(texturesToDraw[i], position, Color.SomeDarkColor)
        }
    }
