    // less specific constraint first so that it doesn't overwrite more general ones
    mock.Setup(ms => ms.ValidateUser(
            It.IsAny<string>(), It.IsAny<string>())
        .Returns(new ValidUserContext());
    mock.Setup(ms => ms.ValidateUser(
            It.Is<string>(u => u == username), It.Is<string>(p => p == password))
        .Returns(new ValidUserContext { Principal = principal });
