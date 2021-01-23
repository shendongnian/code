    ChildDTO dto = null;
    Child childAlias = null;
    var query = _session.QueryOver<Parent>()
    .JoinAlias(x=>x.Children, ()=>childAlias, JoinType.InnerJoin)
    .Where(x=>x.Id==id)
    .SelectList(list=>list
       .Select(x=>childAlias.SomeProperty).WithAlias(()=>dto.SomeProperty)
       .Select(x=>childAlias.SomeOtherProperty).WithAlias(()=>dto.SomeOtherProperty))
    .TransformUsing(Transformers.AliasToBean<ChildDTO>())
    .List<ChildDTO>();
