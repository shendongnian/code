    public void Update(GameTime gameTime, MouseState ms)
    {
        if (currentObject != null && this != currentObject) return;
        if ((ButtonState.Pressed == Mouse.GetState().LeftButton))
        {
            if (RectObject.Intersects(new Rectangle(ms.X, ms.Y, 0, 0)))
            {
                Dragged = true;
                currentObject = this;
            }
        }
        else
        ...
    }
