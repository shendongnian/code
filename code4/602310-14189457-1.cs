    private async void SetUser(int userId)
    {
        ServiceClient proxy = new ServiceClient();
        _user = await proxy.GetUserAsync(userId);
    }
