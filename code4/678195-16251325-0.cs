    var type = list.GetType();
    if(type.IsGenericType && 
       type.GetGenericTypeDefinition().Equals(typeof(List<>)))
    {
        // do work
    }
