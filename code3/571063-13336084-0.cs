    public void TestRead()
    {
      var streamMock = new Mock<INetworkstreamWrapper>();
       streamMock
                .Setup(m => m.Read(It.IsAny<byte[]>(), 
                                   It.IsAny<int>(), 
                                   It.IsAny<int>()))
                .Callback((byte[] buffer, int offset, int size) => buffer[0] = 128);
       var myBuffer = new byte[10];
       streamMock.Object.Read(myBuffer,0,10);
       Assert.AreEqual(128, myBuffer[0]);
    }
