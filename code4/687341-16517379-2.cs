    var list = new List<Data>();
    //bulid a expression tree to create a paramter
    ParameterExpression param = Expression.Parameter(typeof(Data), "d");
    //bulid expression tree:data.Field1
    Expression selector = Expression.Property(param,typeof(Data).GetProperty("Field1"));
    Expression pred = Expression.Lambda(selector, param);
    //bulid expression tree:Select(d=>d.Field1)
    Expression expr = Expression.Call(typeof(Queryable), "Select",
        new Type[] { typeof(Data), typeof(string) },
        Expression.Constant(list.AsQueryable()), pred);
    //create dynamic query
    IQueryable<string> query = list.AsQueryable().Provider.CreateQuery<string>(expr);
    var result=query.ToList();
