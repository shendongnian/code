    sessionMock
        .Setup(x => x.Get<User>(
            It.Is<object>(d => d.GetPropertyValue<string>("Name") == "test 1")))
        .Returns(new User{Id = 1});
    sessionMock
        .Setup(x => x.Get<User>(
            It.Is<object>(d => d.GetPropertyValue<string>("Name") == "test 2")))
        .Returns(new User { Id = 2 });
