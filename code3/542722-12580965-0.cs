    public User GetUserByUserNameAndPassword(string userName, string userPassword) 
    { 
        using (var context = DataObjectFactory.CreateContext()) 
        { 
            var user = context.UserEntities.SingleOrDefault(u => u.UserName == userName && u.UserPassword == userPassword);
            return user !=null ? Mapper.Map(user) : null; 
        } 
    } 
