    container.Register(AllTypes.From( 
        AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetExportedTypes()))
        .BasedOn(typeof(IGridEntityService<,>))
        .Unless(t => t.IsGenericTypeDefinition)
        .WithService.Select((_, baseTypes) =>
        { 
            return 
                from t in baseTypes
                where t.IsGenericType
                let td = t.GetGenericTypeDefinition()
                where td == typeof(IGridEntityService<,>)
                select t;
        })
        .Configure(c => c.LifeStyle.Transient));
    container.Register(Component
        .For(typeof(IGridEntityService<,>))
        .ImplementedBy(typeof(GridEntityService<,>)))
