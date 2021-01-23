    [Test]
    public void Test()
    {
        var dictionary = new Dictionary<string, int>
                             {
                                 { "first", 2 },
                                 { "second", 1 },
                                 { "third", 3 },
                                 { "fourth", 1 }
                             };
        int min = dictionary.Values.Min();
        IEnumerable<string> keys = dictionary.Keys.Where(key => dictionary[key] == min);
        Assert.That(keys.Count(), Is.EqualTo(2));
        Assert.That(keys.Contains("second"), Is.True);
        Assert.That(keys.Contains("fourth"), Is.True);
    }
