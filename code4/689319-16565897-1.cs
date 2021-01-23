    public async Task<IEnumerable<User>> getUsers()
    {
        return await getAsync("api/User");
    }
    public async Task<IEnumerable<permission>> getPermission()
    {
        return await getAsync("api/User");
    }
    public async Task<CurrentUser> getCurrentUserInfo(User user)
    {
        return await getAsync("api/User?name=" + user.Name);
    }
