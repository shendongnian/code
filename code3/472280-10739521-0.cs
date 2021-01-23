    ChildDTO dto = null;
    var query = _session.QueryOver<Child>()
    .Where(x=>x.Parent.Id==id)
    .SelectList(list=>list
       .Select(x=>x.SomeProperty).WithAlias(()=>dto.SomeProperty)
       .Select(x=>x.SomeOtherProperty).WithAlias(()=>dto.SomeOtherProperty))
    .TransformUsing(Transformers.AliasToBean<ChildDTO>())
    .List<ChildDTO>();
