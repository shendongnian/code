    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(position.X - width / 2, position.Y - height / 2, width, height);
        }
    }
