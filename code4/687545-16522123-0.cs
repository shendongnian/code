    public bool IsAvailable 
    {
    get
    {
        return _isAvailable;
    }
    set
    {
        if (value)
        {
            this.Shape.BrushColor = ColorAvailable;
        }
        else
        {
            this.Shape.BrushColor = ColorNotAvailable;
        }
        _isAvailable = value;
    }
}
