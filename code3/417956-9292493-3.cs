    ILoginService service;
    #if DEBUG
        service = A.Fake<ILoginService>();
        // you could even set up your fakes to return logged user to
        // automate logging in process:
        var userFake = A.Fake<IUser>();
        A.CallTo(() => service.LogIn(A<string>.Ignored)).Returns(userFake);
    #else
        service = new RealLoginService();
    #endif
    var myWindow = new MyWindow();
    var viewModel = new ViewModel(service);
    myWindow.DataContext = viewModel;
    // ...
