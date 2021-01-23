    [Test]
    public async void ShouldThrow404WhenNotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetByUserName(It.IsAny<string>())).Returns(default(User));
        var userController = new UserController(mockUserRepository.Object) { Request = new HttpRequestMessage() };
    
        var exception = Assert.ThrowsAsync<HttpResponseException>(() => userController.Get("foo"));
   
        Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
