    [Test]
    public void Enqueue_ItemGiven_AddToQueueCalledOnQueueStorage()
    {
        int timesAddToQueueCalled = 0;
    
        var dummyQueueStorage = new Mock<IQueueStorage>();
        var testCommand = new TestCommand();
    
        var queueManager = new AzureCommandQueueManager();
    
        dummyQueueStorage
            .Setup(x => x.AddToQueue(It.IsAny<TestCommand>()))
            .Callback(() => timesAddToQueueCalled++);
    
        queueManager.QueueStorage = dummyQueueStorage.Object;
    
        queueManager.Enqueue(testCommand);
    
        Assert.AreEqual(1, timesAddToQueueCalled);
    }
