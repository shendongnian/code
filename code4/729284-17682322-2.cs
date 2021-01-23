    public Size MySize
    {
        get {            
            return new Size(Width,Height); 
        }
        set {
            Width = value.Width; 
            Height = value.Height; // Set Width/Height appropriately
        }
    }
