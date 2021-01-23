    public void Login(User user, Action<User> action)
    {
        User responseUser = null;
        parse.Users.Login<User>("hello", "99999", r =>
        {
            if (r.Success) 
            { 
                action(r.Data);
            }
            else
            {
                action(null);
            }
        });
    }
