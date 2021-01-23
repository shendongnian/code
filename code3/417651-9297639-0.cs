    private object GetKeyValue<T>(T entity) where T : class
    {
        PropertyInfo key =
            typeof(T)
            .GetProperties()
            .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            
        return key != null ? key.GetValue(entity, null) : null;
    }
    MyEntity instanceOfMyEntity = new MyEntity { MyEntityId = 999; };
    object keyValue = GetKeyValue<MyEntity>(instanceOfMyEntity); // keyValue == 999
