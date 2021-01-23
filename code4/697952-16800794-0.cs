    var entity1 = new MyEntity();
    var entity2 = new MyEntity();
    var entities = new List<MyEntity>{entity1, entity2};
    
    var mockRepository = new Mock<IRespository>();
    
    mockRepository.Setup(r => r.GetObjects("some param")).Returns(entities);
    
    var service = new Service(mockRepository.Object);
    
    service.DoWork("some param");
    //continue the test
