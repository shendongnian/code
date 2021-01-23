    public bool IsAvailable 
    {
        get
        {
            return this.Shape.BrushColor == ColorAvailable;
        }
        set
        {
            this.Shape.BrushColor = value  ? ColorAvailable : ColorNotAvailable;               
        }
    }
