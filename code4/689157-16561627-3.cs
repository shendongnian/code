    public bool Authenticate(User user)
    {
        //in case of forms authentication..
        return Membership.ValidateUser(user.UserName, user.Password);
        //or usual password comparison
        //return user.Password == txtPassword.Text.Trim();
    }
