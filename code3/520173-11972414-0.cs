    static bool IsAuthorized(User user)
    {
        if(user!=null)
        {
            return user.IsAuthorized;
        }
        else
        {
            return false;
        }
    }
