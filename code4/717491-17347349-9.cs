    [Test]
    public void ChangePassword_returns_false_if_user_does_not_exist()
    {
        Mock<IHelper> helper = new Mock<IHelper>();            
        var myClass = new MyClass(ockedDependency.Object);
        myClass.DoSomething(helper.Object.ShouldRun, helper.Object.ShouldNotRun);
        helper.Verify(h => h.ShouldRun(), Times.Once());
        helper.Verify(h => h.ShouldNotRun(), Times.Never());
    }
