    enum Provider
    {
        None = 0, // if "none" is a potential value
        OpenID = 1,
        OAuth =  2,
        Google =   1 << 2 | OpenID,
        Aol =      2 << 2 | OpenID,
        Facebook = 3 << 2 | OAuth,
        Twitter =  4 << 2 | OAuth
    }
    static bool IsOpenID(Provider p)
    {
        return (p & Provider.OpenID) == Provider.OpenID;
    }
    static bool IsOAuth(Provider p)
    {
        return (p & Provider.OAuth) == Provider.OAuth;
    }
