    [Test]
    public void ParallelForEachExceptionsTest()
    {
        var exceptions = new ConcurrentQueue<Exception>();
        var thrown = Assert.Throws<AggregateException>(
            () => Parallel.ForEach(
                Enumerable.Range(1, 4), i =>
                {
                    var e = new Exception(i.ToString());
                    exceptions.Enqueue(e);
                    throw e;
                }));
        CollectionAssert.AreEquivalent(exceptions, thrown.InnerExceptions);
    }
