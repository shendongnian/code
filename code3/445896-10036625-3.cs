    [Test]
    public void TestInAny()
    {
        var filters = new[] {"Bob", "Alice"};
        var items = new[] {"Bob Knob", "Alice Jane", "Tim"};
        var found = items.Where(i => filters.IsInAny(i)).ToList();
    }
