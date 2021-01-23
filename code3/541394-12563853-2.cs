    public IList<TableA> GetTableByPermission(Permission permission)
    {
        return Session.Query<TableA>
                      .Where(x => x.Permission == permission ||
                                  x.Permission == Permission.All)
                      .ToList();
    }
