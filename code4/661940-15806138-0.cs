    _mockUserRepository.Setup(mr => mr.Update(It.IsAny<int>(), It.IsAny<string>()))
                       .Callback((int id, string lastName) => {
                           //do something
                           }).Verifiable();
                      
