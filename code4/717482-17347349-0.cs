    [Test]
    public void ChangePassword_returns_false_if_user_does_not_exist()
    {
        var myClass = new MyClass(mockedDependency.Object);
        bool isExecuted = false;
        Action success = () => isExecuted = true;
        myClass.DoSomething(success, null);
        Assert.IsTrue(isExecuted);
    }
