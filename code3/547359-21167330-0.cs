    [Test]
    public void TestMultiThreadingCodeSynchronously()
    {
        // Arrange
        SomeOtherClass someOtherClassInstance = MockRepository.GenerateMock<SomeOtherClass>();
        DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
        SomeClass systemUnderTest = new SomeClass(taskScheduler, someOtherClassInstance);
        
        // Act
        systemUnderTest.SomeMethod();
        
        // Now execute the new task on
        // the current thread.
        taskScheduler.RunTasksUntilIdle();
    
        // Assert
        someOtherClassInstance.AssertWasCalled(x=>x.SomeOtherMethod());
    }
 
