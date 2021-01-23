    class UI
    {
    List<UIControl> Controls;
    
    Update(MyInputSystem input, flioat dt)
    {
        foreach(var control in Controls)
           control.Update(input, dt);
    }
    
    Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(/*Parameters*/);
        foreach(var control in Controls)
           control.Draw(spriteBatch);
        spriteBatch.End();
    }
    }
