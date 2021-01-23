    FileDownloadEntry fde = // create entry
    Mock<IFooService> serviceMock = new Mock<IFooService>();
    serviceMock.Setup(s => s.AddFileDownloadEntry(fde)).Returns(someReturnValue);
    
    SUT sut = new SUT(serviceMock.Object); // inject dependency
    sut.YourMethod(); // exercise
