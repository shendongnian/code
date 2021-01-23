    [TestMethod]
    public void SOTest16203210()
    {
        int[] source = new int[6] { 1, 2, 3, 4, 5, 6 };
        int[,] destination = new int[3, 2];
        Buffer.BlockCopy(source, 0, destination, 0, source.Length * sizeof(int));
        Assert.AreEqual(destination[0, 0], 1);
        Assert.AreEqual(destination[0, 1], 2);
        Assert.AreEqual(destination[1, 0], 3);
        Assert.AreEqual(destination[1, 1], 4);
        Assert.AreEqual(destination[2, 0], 5);
        Assert.AreEqual(destination[2, 1], 6);
    }
