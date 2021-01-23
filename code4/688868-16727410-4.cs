    public Color Color
    {
        get { return _color ?? Color.Black; }
        set
        {
            if (value != Color)
            {
                _color = value;
            }
        }
    }
