    [Test]
    public void TestMultiThreadingCodeSynchronously()
    {
        // Arrange
        SomeOtherClass someOtherClassMock = MockRepository.GenerateMock<SomeOtherClass>();
        DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
        SomeClass systemUnderTest = new SomeClass(taskScheduler, someOtherClassMock);
        
        // Act
        systemUnderTest.SomeMethod();
        
        // Now execute the new task on
        // the current thread.
        taskScheduler.RunTasksUntilIdle();
    
        // Assert
        someOtherClassMock.AssertWasCalled(x=>x.SomeOtherMethod());
    }
