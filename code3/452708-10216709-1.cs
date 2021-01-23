    [Test]
    public void TestingSomething()
    {
        // Arrange
        Mock<NotMineClassInstance> mockNotMine = new Mock<NotMineClassInstance>();
        mockDep.Setup(x => x.Execute<bool>(It.IsAny<Func<bool>>())).Returns((Func<bool> func) => func());
    
        Mock<Injected1> mockInjected1 = new Mock<Injected1>();
        mockInjected1.Setup(i => i.Method()).Returns(true);
    
        Mock<Injected2> mockInjected2 = new Mock<Injected2>();
        mockInjected2.Setup(i => i.Method()).Returns("xxx");
    
        YourClass yourObject = new YourClass(mockDep.Object, mockInjected1.Object, mockInjected2.Object);
      
        // Act
        MyType my = yourObject.MyMethod();    
        // Assert
        mockNotMine.Verify(d => d.Execute<bool>(It.IsAny<Func<bool>>()));
        mockInjected1.Verify(i => i.Method());
        mockInjected2.Verify(i => i.Method());
    
        Assert.That(my.Attribute, Is.EqualTo("xxx"));
        Assert.That(my.OtherAttribute, Is.EqualTo(someValue));            
    }
