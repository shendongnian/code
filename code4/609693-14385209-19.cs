    public ServiceHost(Type t, params Uri[] baseAddresses) :
                base(t, baseAddresses) { }
    protected override void OnOpening()
    {
        base.OnOpening();
    
        //adding the extra behavior
        this.Description.Behaviors.Add(new ExceptionManager());
