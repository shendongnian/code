    private UserRepository()
    {
    }
    private async Task InitializeAsync()
    {
        var tempList = await _client.GetUsersAsync();
        foreach(UserDTO item in tempList)
        {
            _users.Add(item);
        }
    }
    public static async Task<UserRepository> Create()
    {
        var ret = new UserRepository();
        await ret.InitializeAsync();
        return ret;
    }
