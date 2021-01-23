    void InitProperties(object obj)
    {
        foreach (var prop in obj.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite))
        {
            var type = prop.PropertyType;
            var constr = type.GetConstructor(Type.EmptyTypes); //find paramless const
            if (type.IsClass && constr != null)
            {
                var propInst = Activator.CreateInstance(type);
                prop.SetValue(obj, propInst, null);
                InitProperties(propInst);
            }
        }
    }
