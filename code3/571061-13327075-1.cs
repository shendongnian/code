    [Test]
    public void MockStreamTest()
    {
        var mock = new Mock<INetworkstreamWrapper>();
        int returnValue = 1;
        mock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                         .Returns(() => returnValue);
        var read = mock.Object.Read(new byte[] { }, 1, 1);
        //Verify the the method was called with expected arguments like this:
        mock.Verify(x => x.Read(new byte[] { }, 1, 1), Times.Once());
        Assert.AreEqual(returnValue, read);
    }
