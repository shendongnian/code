    IQueryable<Foo> source = // YOUR SOURCE HERE
          // in-memory dummy example:
          // source = new[] {
          //    new Foo {Id = 1, Bar = "abc"},
          //    new Foo {Id = 2, Bar = "def"}
          // }.AsQueryable();
    string field = "Bar";
    string stringToSearch = "d";
    var param = Expression.Parameter(typeof (Foo), "x");
    var predicate = Expression.Lambda<Func<Foo, bool>>(
        Expression.Call(
            Expression.PropertyOrField(param, field),
            "Contains", null, Expression.Constant(stringToSearch)
        ), param);
    var projection = Expression.Lambda<Func<Foo, Tuple<int, string>>>(
        Expression.Call(typeof(Tuple), "Create", new[] {typeof(int), typeof(string)},
            Expression.PropertyOrField(param, "Id"),
            Expression.PropertyOrField(param, field)), param);
    Tuple<int,string>[] data = source.Where(predicate).Select(projection).ToArray();
