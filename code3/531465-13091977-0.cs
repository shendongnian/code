    [TestMethod]
    public void DoThingThatShouldUseTheDependency_Condition_Result()
    {
        // arrange
        bool dependencyCalled = false;
        var dependency = new Fakes.StubIDependency()
        {
            DoStuff = () => dependencyCalled = true;
        }
        var target = new ClassUnderTest(dependency);
        // act
        target.DoStuff();
        // assert
        Assert.IsTrue(dependencyCalled);
    }
