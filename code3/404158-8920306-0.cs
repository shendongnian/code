           Type generic = typeof(Repository<>);
    
           Type[] typeArgs = { item.GetType() };
    
           Type constructed = generic.MakeGenericType(typeArgs);
    // This will create Repository<item> type.
