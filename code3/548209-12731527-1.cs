    public void AddUser(User user)
    {
    if(!IsValidUser(user))
     throw new FaultException<BusinessFault>(new BusinessFault(BusinessFaultType.Validation, "Username",ErrorCode.AlreadyExists); 
    using (var context = DataObjectFactory.CreateContext())
        {
            var userEntity = Mapper.Map(user);
            context.AddObject("UserEntities", userEntity);
            context.SaveChanges();
            return Mapper.Map(userEntity);
        } 
    }
