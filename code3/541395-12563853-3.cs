    public bool HasPermission(Guid guid, Permission permission)
    {
        var tableA = Session.Query<TableA>.SingleOrDefault(x => x.Id == guid);
        if (tableA != null)
            return (tableA.Permission & permission) == permission;
        // Return false or whatever is appropriate.
        return false;
    }
