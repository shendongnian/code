    [Test]
    public void foo()
    {
        var mock = new Mock<IBlah>();
        var enumerable = Enumerable.Range(1, 10);
        var baz = new Baz(mock.Object);
        baz.Sum(enumerable.Where(x => x%2 == 0));
        mock.Verify(p => p.Sum(It.Is<IEnumerable<int>>(z => z.All(x => x%2==0))));
    }
