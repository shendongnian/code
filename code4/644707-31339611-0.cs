    // setup mock dependency (here with NSubstitute)
    TaskCompletionSource<Entity> queryTaskDriver = new TaskCompletionSource<Entity>();
    IEntityFacade entityFacade = Substitute.For<IEntityFacade>();
    
    entityFacade.GetByIdAsync(Arg.Any<string>()).Returns(queryTaskDriver.Task);
    // later on, in the "Act" phase
    private void When_Task_Completes_Successfully()
    {
      queryTaskDriver.SetResult(someExpectedEntity);
      // ...
    }
    private void When_Task_Gives_Error()
    {
      queryTaskDriver.SetException(someExpectedException);
      // ...
    }
