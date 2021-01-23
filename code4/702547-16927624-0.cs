    // arrange
    var service = Mock<IAuthenticationService>()
      .Setup(s => s.IsUserLoginValid(It.IsAny<string>(), It.IsAny<string>()))
      .Returns(true);
    
    // act
    // in LogUserIn, we set the HomeOrg property
    var result = SUT.LogUserIn("user", "password");
    
    // assert
    service.VerifySet(d => d.HomeOrg = "home-org");
