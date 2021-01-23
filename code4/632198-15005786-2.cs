    var subset = _connection.Wait(_connection.SortedSets.RangeString(
        _db, thisChannel, span.TotalSeconds - 10000, span.TotalSeconds, offset: 0, count: 50));
    Assert.AreEqual(1, subset.Length);
    Config.AssertNearlyEqual(val, subset[0].Value);
    Assert.AreEqual(message, subset[0].Key);
