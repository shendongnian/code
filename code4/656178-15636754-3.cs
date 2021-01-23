        [Test]
        public async void ShouldThrow404WhenNotFound()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByUserName(It.IsAny<string>())).Returns(default(User));
            var userController = new UserController(mockUserRepository.Object) { Request = new HttpRequestMessage() };
            Action<HttpResponseException> asserts = exception => Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            await AssertEx.ThrowsAsync(() => userController.Get("foo"), asserts);
        }
