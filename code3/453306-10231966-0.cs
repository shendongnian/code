    Action saveAction = null;
    contextMock
      .Setup(c => c.Save(It.IsAny<Action>())
      .Callback<Action>(a => saveAction = a);
    // Call delete...
    Assert.IsNotNull(saveAction);
    saveAction();
    
    // Assert that DoSomethingElseWhenSaveCompleted was done
