    public MiddleClass(TopClass parent)
    {
        this.Parent = parent;
    }
    public TopClass()
    {
       this.middleClass = new MiddleClass(this);
    }
