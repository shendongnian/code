    mock.Setup(ms => ms.ValidateUser(
            It.Is<string>(u => u == username), It.Is<string>(p => p == password))
        .Returns(new ValidUserContext { Principal = principal });
    mock.Setup(ms => ms.ValidateUser(
            It.Is<string>(u => u != username), It.Is<string>(p => p != password))
        .Returns(new ValidUserContext());
