	[Test]
	public void TransferHandlesDisconnect()
	{
		// ... set up config here
		var methodTester = new Mock<Transfer>(configInfo);
		methodTester.CallBase = true;
		methodTester
            .Setup(m => 
                m.GetFile(
                    It.IsAny<IFileConnection>(), 
                    It.IsAny<string>(), 
                    It.IsAny<string>()
                ))
			.Throws<System.IO.IOException>();
		methodTester.Object.TransferFiles("foo1", "foo2");
		Assert.IsTrue(methodTester.Object.Status == TransferStatus.TransferInterrupted);
	}
