        [Test]
        public void ShouldThrow404WhenNotFound()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByUserName(It.IsAny<string>())).Returns(default(User));
            var userController = new UserController(mockUserRepository.Object) { Request = new HttpRequestMessage() };
            var aggregateException = Assert.Throws<AggregateException>(() => userController.Get("foo").Wait());
            var httpResponseException = aggregateException.InnerExceptions
                .FirstOrDefault(x => x.GetType() == typeof(HttpResponseException)) as HttpResponseException;
            Assert.That(httpResponseException, Is.Not.Null);
            Assert.That(httpResponseException.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
