    public IEnumerable<Users> GetUsers(int sectionID)
    {
        var _user = DataBase.ProcsContext.GetRoster<Users>(sectionID, u => new Users
        {
            Name = UserColumnMap.Name(u),
            Email = UserColumnMap.Email(u)
        },
        resultsPerPage: 250);
        return _user;
    }
