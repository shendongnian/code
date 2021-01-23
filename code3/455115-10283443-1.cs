    var childId = "..."; 
       
    Child childAlias = null;
    session.QueryOver<Parent>
      .JoinAlias(parent => parent.Child, () => childAlias)
      .Where(() => childAlias.Id == childId)
      .TransformUsing(Transformers.DistinctRootEntity)
      .SingleOrDefault();
