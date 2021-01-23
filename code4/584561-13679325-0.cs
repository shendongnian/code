    void ExecuteAction(Action action)
    {
       //Log TestFixture, TestMethod, Action
       
       //Execute actual action
    }
    
    [Test]
    void TestMethod1()
    {
        ExecuteAction(Run(new Sleep { Seconds = 10 } ));
    }
