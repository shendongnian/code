    [Test]
    public void CountWords()
    {
        const string sample = "How you doing today ?";
        MatchCollection collection = Regex.Matches(sample, @"[\S]+");
        var numberOfWords = collection.Count;
        //numberOfWords is 5
        Assert.IsTrue(numberOfWords == 5);
    }
