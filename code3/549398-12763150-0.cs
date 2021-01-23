    // lazy-loaded property
    public MembershipUserCollection UsersCollection
    {
        get
        { 
            if (_usersCollection == null)
            {
                _usersCollection = Membership.GetAllUsers();
            }
            return _usersCollection;
        }
    }
    MembershipUserCollection _usersCollection;
