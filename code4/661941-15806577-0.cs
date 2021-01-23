    Mock<IUsers> _mockUserRepository = new Mock<IUsers>();
            _mockUserRepository.Setup(mr => mr.Update(It.IsAny<int>(), It.IsAny<string>()))
                                .Callback((int id, string name) =>
                                    {
                                        //Your callback method here
                                    });
     //check to see how many times the method was called
     _mockUserRepository.Verify(mr => mr.Update(It.IsAny<int>(), It.IsAny<string>()), Times.Once());
