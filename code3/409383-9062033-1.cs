    [TestMethod]
    public void FindMinimum() {
        int indexA = 6;
        int indexB = 7;
        int indexC = 1;
        Assert.AreEqual(1, new[] { indexA, indexB, indexC }.Min());
    }
