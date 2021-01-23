    cb.RegisterAssemblyTypes(assembly).Where(type =>
    {
        var implementations = type.GetInterfaces();
        
        if (implementations.Length > 0)
        {
            var iface = implementations[0];
            
            var implementers =
                from t in assembly.GetTypes()
                where t.GetInterfaces().Contains(iface)
                select t;
                
            return implementers.Count() == 1;
        }
        
        return false;
    })
    .As(t => t.GetInterfaces()[0]);
