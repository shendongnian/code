    [Test]
    public void MockStreamTest()
    {
        var mock = new Mock<INetworkstreamWrapper>();
        int returnValue = 1;
        mock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                         .Returns((byte[] r,int o, int s) =>
                                      {
                                          r[0] = 1;
                                          return returnValue;
                                      });
        var bytes = new byte[1024];
        var read = mock.Object.Read(bytes , 1, 1);
        //Verify the the method was called with expected arguments like this:
        mock.Verify(x => x.Read(bytes, 1, 1), Times.Once());
        Assert.AreEqual(returnValue, read);
        Assert.AreEqual(1,bytes[0]);
    }
