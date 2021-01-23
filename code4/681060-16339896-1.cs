    Order orderAlias = null;
    Unit unitAlias = null;
    var query = session.QueryOver<Order>(() => orderAlias)
       .JoinAlias(() => orderAlias.Units, () => unitAlias, JoinType.InnerJoin)
       //.TransformUsing(Transformers.DistinctRootEntity) if you have duplicates
       .OrderBy(x => x.PONumber).Desc.Take(5);
