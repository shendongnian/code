    [Test]
    public void ChangePassword_returns_false_if_user_does_not_exist()
    {
        var myClass = new MyClass(mockedDependency.Object);
        bool isExecuted = false; // flag to check
        Action success = () => isExecuted = true; // set flag to true when executed
        myClass.DoSomething(success, null);
        Assert.IsTrue(isExecuted); // check if flag changed
    }
