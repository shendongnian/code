    myMock.GetType().GetInterfaces()
        .Single(x => x.IsGenericType && 
                     x.GetGenericTypeDefinition() == typeof(IDictionary<,>))
        .GetGenericArguments();
    
