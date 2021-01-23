    public User GetUser(string connectionString, string name)
    {
        using(var context = new OrganizationContext(connectionString))
        {
            ....
        }
    }
