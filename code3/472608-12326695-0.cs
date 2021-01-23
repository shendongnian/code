    int userIdOfInterest = ...
    IQueryable<BusinessUnit> units = ...
    
    var initialPermissionedUnits = units.Where(bu => bu.UserPermissions.Any(up => up.User.Id == userIdOfInterest));
    
    var allPermissionedUnits = initialPermissionedUnits;
    for (var i = 0; i < MAX_DEPTH; ++i) {
        allPermissionedUnits = allPermissionedUnits
            .Union(allPermissionedUnits
                .Join(units, pu => pu.BusinessUnitId, u => u.ParentBusinessUnit.BusinessUnitId, (pu, u) => u));
    }
    
    // finally, execute the big query we've built up
    return allPermissionedUnits.ToList();
