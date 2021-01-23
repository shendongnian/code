    class Container
    {
      public int Id { get; private set; }
      public User CreateUser(string userName)
      {
        return new User(this.Id, userName);
      }
    }
    
    class UserAppService
    {
      public void AddUserToContainer(int containerId, string userName)
      {
        var container = this.containerRepository.Get(containerId);    
        var user = container.CreateUser(userName);    
        this.userRepository.Add(user);
      }
    }
