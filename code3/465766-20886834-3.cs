    [Test]
    public void ShouldExecuteLongRunningOperation()
    {
        // Arrange: Inject task scheduler into class under test.
        DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
        MyClass mc = new MyClass(taskScheduler);
         
        // Act: Let async operation create new task
        mc.OperationAsync();
        // Act:  Execute task on the current thread.
        taskScheduler.RunTasksUntilIdle();
     
        // Assert
        ...
    }
 
