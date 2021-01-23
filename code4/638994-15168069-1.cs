    //Arrange
    var repositoryMock = new Mock<IUnitOfWork>();
    repositoryMock.Setup(x => x.Repository.GetQuery<Account>(
            It.IsAny<Expression<Func<T, bool>>>());
        .Returns(accounts.AsQueryable()); // This should not fail any more
    var myClass = new MyClass(repositoryMock.Object); 
