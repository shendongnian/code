    [TestMethod]
    public void EnqueueNullKey_ThrowsArgumentNullException()
    {
       var queue = new YourPriorityQueue<string, IMessage>();
       var message = new SomeFooMessage(); // or use a mock for this
       Assert.Throws(typeof(ArgumentNullException), () => queue.Enqueue(null, message);
    }
       
