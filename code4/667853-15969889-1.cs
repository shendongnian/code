    UserRepository
    {
        IEnumerable<User> GetAll(QueryObject)
        User GetUserById(int id)
        ...
    }
    
    
    var query = new UserQueryObject(status: Status.Single)
    var singleUsers = userRepo.GetAll(query)
    
