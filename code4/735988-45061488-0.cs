    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterOrdered<IListItem>(scope =>
        {
            scope.Register<Item1>();
            scope.Register<Item2>();
        });
    }
