    private IList<User> _allUsers;
    public IEnumerable<User> GetActiveUser
    {
       get { return _allUsers.Where(u => u.IsActive);
    }
