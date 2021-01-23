    var sesion = ... // get session 
    
    var parent = sesion.CreateCriteria<Parent>();
    
    //var children = parent.CreateCriteria("Children");
    var children = DetachedCriteria.For(typeof(Child));
    
    // restrict the children
    children.Add(Restrictions.Disjunction()
        .Add(Restrictions.Eq("Color", "green"))
        .Add(Restrictions.Eq("Color", "grey"))
        .Add(Restrictions.Eq("Color", "gold"))
        );
    
    // ad SELECT into this sub-select
    children.SetProjection( Projections.Property("ParentId"));
    
    // filter the parent
    parent
        .Add(Subqueries.PropertyIn("ParentId", children));
    
    
    var list = parent
        .SetMaxResults(10) // does not matter in our example, but ... it should be used always
        .List<Parent>();
