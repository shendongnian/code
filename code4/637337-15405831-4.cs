    [Test]
    public void Compose_MultipleAdapters_NonShared()
    {
        var server = new Server();
        server.Compose();
        Assert.That(server.FirstAdapter, Is.Not.Null);
        Assert.That(server.SecondAdapter, Is.Not.Null);
        Assert.That(server.FirstAdapter, Is.Not.SameAs(server.SecondAdapter));
    }
