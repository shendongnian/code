    User entity = context.Users.Include(u => u.UserActions)
        .Single(u => u.Id == user.Id);
        
    context.Entry(entity).CurrentValues.SetValues(user);
    foreach (var userAction in entity.UserActions.ToList())
        if (!user.UserActions.Any(ua => ua.Id == userAction.Id))
            context.UserActions.Remove(userAction);   // DELETE is important here!
    foreach (var userAction in user.UserActions)
    {
        var userActioninDB = entity.UserActions
            .SingleOrDefault(ua => ua.Id == userAction.Id);
        if (userActionInDB == null)
            entity.UserActions.Add(userActioninDB);
        else
            context.Entry(userActioninDB).CurrentValues.SetValues(userAction);
    }
    context.SaveChanges();
