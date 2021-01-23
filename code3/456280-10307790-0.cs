    var mockFooRepository = new Mock<IFooRepository>();
    mockFooRepository.Setup(r => r.Add(It.IsAny<IBar>()))
        .Returns<IBar>(bar => 
        {
            var item = new Mock<IFooItem>();
            item
                .Setup(i => i.fooItemId)
                .Returns(bar.Id);
                
            return item.Object;
        });
