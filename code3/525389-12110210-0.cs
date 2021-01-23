    // Get generic type argument for everything
    Type theType = bsTotalBindingSource.DataSource
        .GetType().GetGenericArguments()[0];
    // Convert your IEnumerable<?>-in-an-object to IQueryable<?>-in-an-object
    var asQueryable =
        // Get IEnumerable<?> type
        typeof(IEnumerable<>)
        .MakeGenericType(new[] { theType })
        // Get IEnumerable<?>.AsQueryable<?> method
        .GetMethod(
            "AsQueryable",
            new Type[] { theType },
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Public)
        // Call on the input object
        .Invoke(bsTotalBindingSource.DataSource, new object[0]);
    // Sort this queryable
    var asSortedQueryable =
        // Get the YourType<?> generic class your sorting generic method is in?
        // If your class isn't generic I guess you can skip the MakeGenericType.
        typeof(yourtype)
        .MakeGenericType(new[] { theType })
        // Get the OrderUsingSortExpression<?> method
        .GetMethod(
            "OrderUsingSortExpression",
            new Type[] { theType },
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.Public)
        // Call on the IQueryable<?> object
        .Invoke(dataSource, new object[] { order });
    // Set this object to the data source
    bsTotalBindingSource.DataSource = asSortedQueryable;
