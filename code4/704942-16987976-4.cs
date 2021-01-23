    public override IRegister RegisterType(Type serviceType, Type implementationType, dynamic arguments)
    {
        // StructureMap specific code
        Container.Configure(x =>
        {
            var instance = x.For(serviceType).Use(implementationType);
            foreach (PropertyInfo p in arguments.GetType().GetProperties())
            {
                string key = p.Name;
                object value = p.GetValue(arguments, null);
                instance.CtorDependency<string>(key).Is(value));
            }
         });
        return this;
    }
