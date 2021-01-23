    public IQueryable<UserGroup> UserGroups
    {
        get
        {
            var db = new MainDataContext();
            return db.UserGroupUsers.Where(x => x.UserId == this.Id)
                                    .Select(x => x.UserGroup);
        }
    }
    public IQueryable<UserDynamicField> DynamicFields
    {
        get
        {
            // 1 query
            return this.UserGroups.SelectMany(x => x.UserGroupDynamicFields); 
        }
    }
