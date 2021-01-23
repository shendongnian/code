    int userIdOfInterest = ...
    IQueryable<BusinessUnit> units = ...
    
    // start with a query of all units the user has direct permission to
    var initialPermissionedUnits = units.Where(bu => bu.UserPermissions.Any(up => up.User.Id == userIdOfInterest));
    
    var allPermissionedUnits = initialPermissionedUnits;
    for (var i = 0; i < MAX_DEPTH; ++i) {
        allPermissionedUnits = allPermissionedUnits
            // this union combines all the permissioned units found so far
            // with all children of those units, and gives us an implicit DISTINCT
            .Union(allPermissionedUnits
                .Join(units, pu => pu.BusinessUnitId, u => u.ParentBusinessUnit.BusinessUnitId, (pu, u) => u));
    }
    
    // finally, execute the big query we've built up
    return allPermissionedUnits.ToList();
