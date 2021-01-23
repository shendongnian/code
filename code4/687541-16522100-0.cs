    private bool _isAvailable;
    
    public bool IsAvailable 
    {
        get
        {
            return _isAvailable;
        }
    
        set
        {
            if (value == true)
            {
                this.Shape.BrushColor = ColorAvailable;
                _isAvailable = true;
            }
            else
            {
                this.Shape.BrushColor = ColorNotAvailable;
                _isAvailable = false;
            }
        }
    }
