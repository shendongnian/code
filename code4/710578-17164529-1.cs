    public StructureMap.IContainer ConfigureStructureMap()
    {
        StructureMap.IContainer structureMap;
        StructureMap.Configuration.DSL.Registry registry = 
            new StructureMap.Configuration.DSL.Registry();
        registry.Scan(scanner =>
        {
            scanner.TheCallingAssembly();
            scanner.ConnectImplementationsToTypesClosing(typeof(IIngredient<>));
        });
        structureMap = new StructureMap.Container(registry);
        structureMap.Configure(cfg => 
            cfg.For(typeof(IRecipe<>)).Use(typeof(Recipe<>)));
        return structureMap;
    }
