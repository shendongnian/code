    class FakeUserRepository : IUserRepository
    {
        public List<User> Users = new List<Users>();
        public User Get(long id)
        {
             return Users.FristOrDetail(x=>x.Id = id);
        }
    }
    var id = 1;
    var user = new User();
    var repository = new FakeUserRepository();
    repository.Users.Add(user);
    var sut = new Service(repository);
    var result = sut.Get(id);
    Assert.Equals(user, result);    
