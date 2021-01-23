    public object Target { get; set; }
    
    public Array TargetValues
    {
        get
        {
            if (this.Target is Array)
            {
                return this.Target;
            }
    
            return new[] { this.Target };
        }
    }
