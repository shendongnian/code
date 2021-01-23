    var userServiceFake = A.Fake<IUserService>();
    var testedViewModel = new LoginViewModel(userServiceFake);
    // prepare data for test
    var passwordBox = new PasswordBox { Password = "password" };
    testedViewModel.UserName = "TestUser";
    // execute test
    testedViewModel.LoginCommand.Execute(passwordBox);
    
    // verify
    A.CallTo(() => userServiceFake.Login(
        "TestUser",
        passwordBox.SecurePassword,
        A<Action<bool>>.Ignored)
    ).MustHaveHappened();
