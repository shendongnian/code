    // at the top of the file
    using Moq.Protected;
    // ...
    var drawingSystemStub = new Mock<IDrawingSystemUow>();
    var testedClass = new Mock<UserService>();
    testedClass 
      .Protected()
      .Setup<IDrawingSystemUow>("Uow")
      .Returns(drawingSystemStub.Object);
    
    // setup drawingSystemStub as any other stub
    // exercise test
    var result = testedClass.Object.UserExists(...);
