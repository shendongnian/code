    reposistory = new Mock<IUserRepository>();
    var id = 1;
    var user = new User();
    repository.Setup(x=> x.Get(id)).Returns(user);
    var sut = new Service(repository.Object);
    var result = sut.Get(id);
    Assert.Equals(user, result);
