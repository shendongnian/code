    if(null != restrictedProperty )
    {
        var notEqualExp = Expression.NotEqual(parameter,
                                Expression.Constant(restrictedValue, typeof(string)));
        resultExp = Expression.Call(
                typeof(Queryable), 
                "Where", 
                new Type[] { type }, 
                resultExp, 
                Expression.Lambda(notEqualExp, parameter));
    }
