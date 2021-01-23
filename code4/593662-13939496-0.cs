    // Create objects
    var commLayerMock = new Mock<ICommLayer>();
    var commHandler = new CommHandler(commLayerMock.Object);
    // subscribe to CommHandler event
    bool raised = false;
    commHandler.OnCommHandlerEvent += delegate { raised = true; };
    // Raise CommLayer event, ensure CommHandler event was subsequently raised
    commLayerMock.Raise(m => m.OnCommLayerEvent += null, new CommLayerEventArgs());
    Assert.True(raised);
