    private bool _IsAvailable; //private field
    public bool IsAvailable 
    {
        get
        {
            return _IsAvailable;
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
            _IsAvailable = value;
        }
    }
