    var user = Membership.GetUser();
    if (user != null)
    {
        object userKey = user.ProviderUserKey;
        if (userKey != null)
        {
            // Try convert the value to an int.
            // Do whatever.
        }
    }
