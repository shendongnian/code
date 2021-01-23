    int userIdOfInterest = ...
    IQueryable<BusinessUnit> units = ...
    
    // start with a query of all units the user has direct permission to
    var initialPermissionedUnits = units.Where(bu => bu.UserPermissions.Any(up => up.User.Id == userIdOfInterest));
    
    var allHierarchyLevels = new Stack<IQueryable<BusinessUnit>();
    allHierarchyLevels.Push(initialPermissionedUnits);
    for (var i = 0; i < MAX_DEPTH; ++i) {
        // get the next level of permissioned units by joining the last level with 
        // it's children
        var nextHierarchyLevel = allHierarchyLevels.Peek()
                // if you set up a Children association on BusinessUnit, you could replace
                // this join with SelectMany(parent => parent.Children)
                .Join(units, parent => parent.BusinessUnitId, child => child.ParentBusinessUnit.BusinessUnitId, (parent, child) => child));
        allHierarchyLevels.Push(nextHierarchyLevel);
    }
    // build an IQueryable<> which represents ALL units the query is permissioned too
    // by UNIONING together all levels of the hierarchy (the UNION will eliminate duplicates as well)
    var allPermissionedUnits = allHierarchyLevels.Aggregate((q1, q2) => q1.Union(q2));
    
    // finally, execute the big query we've built up
    return allPermissionedUnits.ToList();
