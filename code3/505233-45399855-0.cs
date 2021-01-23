    var stream = new ChunkedStream(pool, asOutputStreamOnDispose: true);
    
    using (var writer = new StreamWriter(stream))
    {
        writer.Write("hello world");
    }
    Assert.AreEqual(0, stream.Position);
    Assert.AreEqual(ChunkedStreamState.ReadForward, stream.State);
    Assert.AreEqual(3, pool.TotalAllocated);
    using (var reader = new StreamReader(stream))
    {
        Assert.AreEqual("hello world", reader.ReadToEnd());
        Assert.AreEqual(0, pool.TotalAllocated);
    }
    Assert.AreEqual(ChunkedStreamState.Closed, stream.State);
