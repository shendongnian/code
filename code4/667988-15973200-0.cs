    [TestCase]
    public void MyTestDetachingBeforeAssert()
    {
        bool finishedCalled = false;
        var eventListener = new EventHandler((sender, e) => finishedCalled = true);
            MyClass.Finished += eventListener;
            // Can lead to detach problems if this throws an exception!
            MyClass.DoSomething();
            MyClass.Finished -= eventListener;
            Assert.That(finishedCalled);
    }
    [TestCase]
    public void MyTestDetachingInFinally()
    {
        bool finishedCalled = false;
        var eventListener = new EventHandler((sender, e) => finishedCalled = true);
        try
        {
            MyClass.Finished += eventListener;
            MyClass.DoSomething();
            Assert.That(finishedCalled);
        }
        finally
        {
            MyClass.Finished -= eventListener;
        }
    }
