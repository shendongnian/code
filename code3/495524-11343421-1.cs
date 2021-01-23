    from b in Model.CompetitorBests
    group b by new { b.BestTypeName, b.BestTypeOrder } into grp
    orderby grp.Key.BestTypeOrder
    select new
    {
        BestType = grp.Key.BestTypeName,
        Results = from d in grp
                  group d by d.DisciplineName into grp2
                  select new
                  {
                      DisciplineName = grp2.Key,
                      Results = grp2
                  }
    };
