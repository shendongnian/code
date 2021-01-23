    public User CreateUser(string userName)
    {
      if (this.userRepository.Exists(userName))
        throw new Exception();
      var user = new User(userName);
      this.userRepository.Add(user);
      return user;
    }
