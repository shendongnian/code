    static void Main()
    {
        IEnumerable<FileInfo> infoList = XXX; // your source to sort
        var orderByMeth = typeof(Enumerable).GetMethods().Single(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
        var tFileInfo = typeof(FileInfo);
        foreach (var prop in tFileInfo.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
        {
            var tKey = prop.PropertyType;
            var xParam = Expression.Parameter(tFileInfo);
            var propBody = Expression.Property(xParam, prop.GetMethod);
            var lambda = Expression.Lambda(propBody, xParam);
            var func = lambda.Compile();
            var orderByMethConstr = orderByMeth.MakeGenericMethod(tFileInfo, tKey);
            var result = orderByMethConstr.Invoke(null, new object[] { infoList, func, });
            var infoListOrdered = (IOrderedEnumerable<FileInfo>)result;
                
            // keep infoListOrdered; foreach through it to get that particular ordering
        }
    }
