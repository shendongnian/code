    List<UIControl> Children { get; protected set; }
    
    
    Update(MyInputSystem input, float dt)
    {
        UpdateChildren(input, dt);
    }
    
    UpdateChildren(MyInputSystem input, float dt)
    {
        foreach(var child in Children)
            child.Update(input, dt);
    }
    
    Draw(SpriteBatch spriteBatch)
    {
        DrawChildren(spriteBatch);
    }
    
    DrawChildren(SpriteBatch spriteBatch)
    {
        foreach(var child in Children)
            child.Draw(spriteBatch);
    }
