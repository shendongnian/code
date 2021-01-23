    UserProfile userProfileAlias = null;
    Log logAlias = null;
    
    session.QueryOver(() => userProfileAlias)
                  .JoinAlias(() => userProfileAlias.Logs, () => logAlias)
                  .Select(
                      Projections.Distinct(Projections.Property(() => userProfileAlias.Name))))
                  .OrderBy(() => userProfileAlias.Name).Asc
                  .List<string>();
