    [Association(Storage = "_user", ThisKey = "UserId", OtherKey="Id")]
    public User User
    {
        get { return _user.Entity; }
        set { _user.Entity = value; }
    }
    private EntityRef<User> _user;
