    public static implicit operator User(JsonUser user)
    {
        return new User
            {
                Name = user.Name,
                Roles = user.Roles
                            .Select(kvp => new Role { Id = kvp.Key, Name = kvp.Value.Name})
                            .ToArray()
            };
    }
