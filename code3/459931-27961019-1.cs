        [TestMethod]
        public void Should_return_OK_when_valid_file_posted()
        {
            //Arrange
            var sut = new yourController();
            
            sut.ControllerContext = FakeControllerContextWithMultiPartContentFactory.Create();
            //Act
            var result = sut.Post();
            //Arrange
            Assert.IsType<OkResult>(result.Result);
        }
