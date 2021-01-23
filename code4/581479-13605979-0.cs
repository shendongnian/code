    [TestMethod]
    public void Post_WhenNotFull_ReturnsTrue()
    {
        var block = new BufferBlock<int>(new DataflowBlockOptions {BoundedCapacity = 1});
        var result = block.Post(13);
            
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Post_WhenFull_ReturnsFalse()
    {
        var block = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1 });
        block.Post(13);
        var result = block.Post(13);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void SendAsync_WhenNotFull_ReturnsCompleteTask()
    {
        // This is an implementation detail; technically, SendAsync could return a task that would complete "quickly" instead of already being completed.
        var block = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1 });
        var result = block.SendAsync(13);
        Assert.IsTrue(result.IsCompleted);
    }
    [TestMethod]
    public void SendAsync_WhenFull_ReturnsIncompleteTask()
    {
        var block = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1 });
        block.Post(13);
        var result = block.SendAsync(13);
        Assert.IsFalse(result.IsCompleted);
    }
    [TestMethod]
    public async Task SendAsync_BecomesNotFull_CompletesTask()
    {
        var block = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 1 });
        block.Post(13);
        var task = block.SendAsync(13);
        block.Receive();
        await task;
    }
