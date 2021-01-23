    var user = session.Load<User>(userId);
    userPhoto.User = user;
    session.Save(userPhoto);
    if (NHibernateUtil.IsInitialized(user))
    {
        user.Photos.Add(userPhoto);
    }
