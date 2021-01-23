        var overrideMethod = typeof(AutoPersistenceModel).GetMethod("Override");
        
        foreach (var type in typeof(IFoo).Assembly)
        {
            if (typeof(IFoo).IsAssignableFrom(type))
            {
                overrideMethod.MakeGenericMethod(type).Invoke(new Action<IFoo>(m => m.HasMayToMany(...)));
            }
        }
