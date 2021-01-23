    public override void Configure(Funq.Container container)
    {
        //All Registrations and Instances are singleton by default in Funq
        container.Register(new GlobalState()); 
    }
