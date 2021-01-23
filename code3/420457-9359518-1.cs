    private readonly static int[] Source = { 2, 3, 4 };
    [TestMethod]
    public void TestMethod1() {
        Assert.IsTrue(new []{ 2, 3, 4, 2}.SequenceEqual(GetSequence(Source,4)));
        Assert.IsTrue(new[] { 2, 3, 4, 2, 3  }.SequenceEqual(GetSequence(Source, 5)));
        Assert.IsTrue(new[] { 2, 3, 4, 2, 3, 4 }.SequenceEqual(GetSequence(Source, 6)));
        Assert.IsTrue(new[] { 2, 3, 4, 2, 3, 4, 2 }.SequenceEqual(GetSequence(Source, 7)));
    }
    private static int[] GetSequence(IEnumerable<int> src, int count) {
        var srcRepeatCount = count / src.Count() + 1;
        return Enumerable.Repeat(src, srcRepeatCount).SelectMany(itm => itm).Take(count).ToArray();
    }
