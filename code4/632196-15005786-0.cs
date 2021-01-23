    [Test]
    public void SO14991819()
    {
        const int _db = 0;
        const string thisChannel = "SO14991819";
        const string message = "hi";
        using (var _connection = Config.GetUnsecuredConnection())
        {
            _connection.Keys.Remove(_db, thisChannel); // start from known state
            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            double val = span.TotalSeconds;
            _connection.SortedSets.Add(_db, thisChannel, message, val, false);
            var subset = _connection.Wait(_connection.SortedSets.Range(
                _db, thisChannel, span.TotalSeconds - 10000, span.TotalSeconds, offset: 0, count: 50));
            Assert.AreEqual(1, subset.Length);
            Config.AssertNearlyEqual(val, subset[0].Value);
            Assert.AreEqual(message, Encoding.UTF8.GetString(subset[0].Key));
        }
    }
