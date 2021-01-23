    protected override IEnumerable<Assembly> SelectAssemblies()
    {
       return new[]
       {
           Assembly.GetExecutingAssembly(),
           typeof(MainViewModel).Assembly
       };
    }
