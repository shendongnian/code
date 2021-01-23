    //Arrange
    var mockBeep = new Mock<Interfaces.IBeep>();
    mockBeep.Setup(b => b.Beeping())
    .Returns(true);
    
    // Act
    
    var result = myClass.BeepInTime(myTime, myBeepTime, mockBeep.Object);
    
    ...
