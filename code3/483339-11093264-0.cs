    public override void Load()
    {
        Bind<IMainControllingViewModelFactory>().ToFactory();
        ... ... //other bindings
    }
