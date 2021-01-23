    var comparer = new RoleComparer();
    User commentUser = userRepository.GetUserById(comment.userId);
    Role commentUserRole = context.Roles.Single(x=>x.Name == "admin");
    if(commentUser.Roles.Contains(commentUserRole, comparer))
    {
        // ...
    }
