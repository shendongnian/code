    ITestInterface myObj = new GenericFactory<ITestInterface>(
        () => {
        var username = GetMyUserName();
        var password = GetMyPassword();
        return new TestClass(username, password)
    }).CreateObject() as ITestInterface;
