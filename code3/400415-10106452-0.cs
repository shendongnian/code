    [TestMethod]
    [ExpectedException(ExpectedException = typeof(ArgumentNullException)]
    public void EnqueueNullKey_ThrowsArgumentNullException()
    {
        /* Arrange */
        var pq = new PriorityQueue<string, IMessage>();
    
        /* Act */
        pq.Enqueue(null, null);
    }
