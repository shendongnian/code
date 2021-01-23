    public override Type BehaviorType
    {
        get { return this.GetType(); }
    }
 
    protected override object CreateBehavior()
    {
        return this;
    }
