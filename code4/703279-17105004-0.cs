    private User GetUser(long id)
    {
        var user = Services.UserService.GetById(id);
        if (user.Client == null && CurrentUser.Id == user.Id)
            user.Client = Services.ClientService.GetByClient(CurrentUser.Client);
        return user;
    }
