    public User Get(int id)
    {
       return new User()
       {
          UserId = id, UserName = "Arnold", ...,
          Addresses = new List<Address>()
          {
             new Address() { ... }
          },
          PhoneNumbers = ...
       };
    }
