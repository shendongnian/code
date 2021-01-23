    dynamic jObject = JObject.Parse(text);
    List<User> users = new List<User>();
    
    foreach(dynamic dUser in jObject)
    {
        List<Role> roles = new List<Role>();
        User user = new User();
        user.Name = dUser.name;
        foreach(PropertyInfo info in dUser.GetType().GetProperties())
        {
            Role role = new Role();
            role.Id = info.Name;
            role.Name = dUser[info.Name].name;
            roles.Ad(role);
        }
        user.Roles = roles.ToArray();
    }
