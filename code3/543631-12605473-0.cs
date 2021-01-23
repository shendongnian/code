	var fooRepositoryMock = new Mock<IFooRepository>();
	var barUiEventMock = fooRepositoryMock.As<IBarUiEvent>();
	bool wasCalled = false;
	barUiEventMock.Object.BarProcessed += (s, e) => wasCalled = true;
	fooRepositoryMock
	    .Setup(m => m.SearchForBars(barsToFind))
		.Returns(barsFound)
		.Raises(
            foo => barUiEventMock.Object.BarProcessed += null,
            new BarFoundEventArgs("")
        );
		
	// ...
	
	Assert.That(wasCalled, Is.True);
	
		
