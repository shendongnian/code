    [Test]
    public void ChangePassword_returns_false_if_user_does_not_exist()
    {
        var myClass = new MyClass(mockedDependency.Object);
        bool isExecuted = false; // flag to check
        myClass.DoSomething(() => isExecuted = true, null);
        Assert.IsTrue(isExecuted); // check if flag changed
    }
