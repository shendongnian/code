    class Button: Label { //Inherit label, so we dont need to create som much new code
    
    public event EventHandler<EventArgs> Click;
    
    Rectangle _Bounds
    public Rectangle Bounds
    {
        get
        {
            if (_Rectangle.Width == 0)
                _Rectangle = new Rectangle((int)Position.X,(int)Position.Y, Texture.Width, Texture.Height);
    
            return _Texture;
        }
    }
    
    override Update(MyInputSystem input, flaot dt)
    {
        if (input.MouseClicked && Bounds.Contains(input.MousePosition))
            Click(this, new EventArgs());
    }
    
    }
