    var results = query.AsExpandable().Select(entity => new AffectProjection()
    {
        AffectID = entity.AffectID,
        AffectCode = entity.AffectCode,
        AffectName = entity.AffectName,
        AbleToDelete = DelegateExpression.Compile()(entity)
    }).ToArray();
