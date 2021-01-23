    public readonly IEnumerable<User> Users = new User[]; // or however this would be initialized
    // To take an item out of the collection
    Users.ToDictionary(u => u.Id).Remove(1123);
    // To take add an item to the collection
    Users.ToList().Add(newuser);
