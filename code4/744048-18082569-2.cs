    // arrange
    var serviceOutput = new List<MyEntity>
    {
       new MyEntity{Id = 1},
       new MyEntity{Id = 2}
    }
    var mockService = new Mock<IMyService>();
    mockService.Setup(s=>s.GetById(1)).Returns(serviceOutput);
       
    var lookupObject = new MyEntity{Id = 1};
       
    var testController = new MyController(mockService.Object);
    
    // act
    var result = controller.FindSimilar(lookupObject);
    
    // assert
    result.Should().Have.Count().EqualTo(1);
    result[0].Should().Be.SameInstanceAs(serviceOutput[0]);
