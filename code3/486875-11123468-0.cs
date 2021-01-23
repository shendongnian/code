    protected override void Update(GameTime gameTime)
    {
        ...
        MouseState ms = Mouse.GetState();
        if (ms.LeftButton == ButtonState.Pressed)
        {
            XNAInterfaceObject control = GetControlAt(ms.X, ms.Y);
            if (control != null)
                control.MouseClickMethod(ms);
        }
        ...
    }
    
    private XNAInterfaceObject GetControlAt(int x, int y)
    {
        for (int i = 0; i < controls.Count; i++)
        {
            if (controls[i].Rectangle.Contains(x, y)
            {
                return controls[i];
            }
        }
        return null;
    }
