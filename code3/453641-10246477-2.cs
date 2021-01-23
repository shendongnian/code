    UserProfile upAlias=null;
    var result = yourNHSession.QueryOver<UserProfile>(() => upAlias)
                  .JoinQueryOver(x => x.Logs)
                  .Select(
                      Projections.Distinct(
                         Projections.ProjectionList()
                         .Add(Projections.Property<UserProfile>(x=>x.Name))))
                  .OrderBy(() => upAlias.Name)
                  .Asc
                  .List<String>().ToList();
