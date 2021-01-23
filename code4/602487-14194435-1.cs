    public bool IsUser(string username)
    {
        using (var client = new datingEntities())
        {
            User user = client.Persons.SingleOrDefault(u => u.Username == username);
            return user != null;
        }
    }
