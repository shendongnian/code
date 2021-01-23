    var iCollectionInterfaces =
          from i in o.GetType().GetInterfaces()
          where i.IsGenericType 
                && i.GetGenericTypeDefinition() == typeof(IColection<>)
          select i;
     
