    var parentSubQuery =
      QueryOver.Of<Child>()
        .WhereRestrictionOn(x => x.Name).IsIn(names)
        .Select(Projections.Group<Child>(x => x.Parent))
        .Where(Restrictions.Ge(Projections.Count<Child>(x => x.Parent), names.Length));
    var parents = session.QueryOver<Parent>() 
      .Fetch(x=>x.Children).Eager // not necessary, just an example
      .WithSubquery.WhereProperty(x => x.Id).In(parentSubQuery )
      .List();
