    public void Update(GameTime pGameTime)
    {
       ...
       MouseState mouseState = Mouse.GetState();
       Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
       if (mouseState.LeftButton == ButtonState.Pressed)
          DoMouseClick(mousePosition);
       ...
    }
