    var zeroIndexIndexer = Expression.MakeIndex
            (Expression.Constant(foos),
             typeof(List<Foo>).GetProperty("Item"), 
             new[] { Expression.Constant(0) });
  
    // .ToString() of the below looks like the following: 
    //  () =>    (value(System.Collections.Generic.List`1[App.Foo]).Item[0].a
    //         *  value(System.Collections.Generic.List`1[App.Foo]).Item[0].b)
    var exp1Clone = ParameterReplacer.Replace<Func<Foo, int>, Func<int>>
                      (exp0, exp0.Parameters.Single(), zeroIndexIndexer);
