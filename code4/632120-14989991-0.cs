    var list = new List<Company>()
    {
        new Company { Foo = "1", NoEmployees = 1 },
        new Company { Foo = "3", NoEmployees = 3 }
    };
    MethodInfo method = typeof(Queryable).GetMethods().Where(x => x.Name == "AsQueryable" && x.IsGenericMethod).First();
    MethodInfo generic = method.MakeGenericMethod(new Type[] { Type.GetType(typeString) });
    var queryable = (IQueryable)generic.Invoke(null, new object[] { list });
    var result = queryable.Select("new (NoEmployees)").Where("NoEmployees > 2").OfType<object>().ToList();
