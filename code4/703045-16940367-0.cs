    List<User> users = ...;
    var roleCounts = users.SelectMany(user => user.UserRoles)
                          .GroupBy(role => role)
                          .Select(roleGroup => new {Role = roleGroup.Key, Count = roleGroup.Count());
    foreach (var roleCount in roleCounts)
    {
        Role role = roleCount.Role;
        int count = roleCount.Count;
        ...
    }
