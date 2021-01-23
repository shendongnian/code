    [Theory, AutoData]
    public void CreateOneOfEachDeclaratively(Generator<User> users)
    {
        var onlineUser = users.Where(u => u.Status == Status.Online).First();
        var offlineUser = users.Where(u => u.Status == Status.Offline).First();
        // Use onlineUser and offlineUser here...
    }
