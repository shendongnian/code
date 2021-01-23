    var obj = "";
    
    var propertyMock1 = new Mock<PropertyInfo>();
    var propertyMock2 = new Mock<PropertyInfo>();
    
    var result1 = "";
    var result2 = "";
    
    var factoryMock = new Mock<IFactory>();
    factoryMock.Setup(f => f.Create(obj, It.IsAny<PropertyInfo>())).Returns<PropertyInfo>(pi => {
        if (pi == propertyMock1.Object)
            return result1;
        if (pi == propertyMock2.Object)
            return result2;
    });
    
    // factoryMock.Setup(f => f.Create(obj, propertyMock2.Object)).Returns(result2);
