    public Color colourStart
    {
        get { return ColorA; }
        set { ColorA = value; RefershBrush(); }
    }
    public Color colourEnd
    {
        get { return ColorB; }
        set { ColorB = value; RefershBrush(); }
    }
    public LinearGradientMode colourGradientStyle
    {
        get { return GradientFillStyle; }
        set { GradientFillStyle = value; RefershBrush(); }
    }
