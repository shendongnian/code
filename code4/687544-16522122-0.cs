    private bool _IsAvailable;
    public bool IsAvailable 
    {
        get
        {
            return _IsAvailable;
        }
    
        set
        {
            this.Shape.BrushColor = value ? ColorAvailable : ColorNotAvailable;
            _IsAvailable = value;
        }
    }
