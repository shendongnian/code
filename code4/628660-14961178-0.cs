    public override void Configure(Funq.Container container)
    {
      //  Other Configuration constructs here
    
      ServiceStackController.CatchAllController = reqCtx => container.TryResolve<HomeController>();
    }
