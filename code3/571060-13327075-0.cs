    [Test]
    public void MockStreamTest()
    {
        var mock = new Mock<INetworkstreamWrapper>();
        int returnValue = 1;
        mock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                         .Returns(returnValue);
        var read = mock.Object.Read(new byte[] {}, 0, 0);
        Assert.AreEqual(returnValue,read);
    }
