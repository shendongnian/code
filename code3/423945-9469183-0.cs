<pre>
    public void UserState GetUserState(User user)
    {
        if (user.IsInRole("Admin"))
        {
            return new UserAdmin(user);
        }
        if (user.Identity.IsAuthenticated)
        {
            return new UserNormal(user);
        }
        return new UserAnonymous();
    }
</pre>
