    public Parent (Parent other)
    {
       //copy other.Properties to this.Properties
    }
    
    public Child (Parent other) : base(other)
    {
       //populate property 51
    }
    public Child (Child other) : base(other)
    {
       //copy property 51
    }
