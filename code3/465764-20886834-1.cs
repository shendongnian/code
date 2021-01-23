    [Test]
    public void ShouldExecuteLongRunningOperation()
    {
        // Arrange:
        // Inject task scheduler into class under test.
        DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
        MyClass mc = new MyClass(taskScheduler);
         
        // Act:
        // Let async operation create new task and then 
        // execute it on the current thread.
        mc.OperationAsync();
        taskScheduler.RunTasksUntilIdle();
     
        // Assert
        ...
    }
 
