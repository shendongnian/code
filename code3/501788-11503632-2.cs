    [Test]
    public void ShouldReturnTrueWhenMyClassIsNotNull()
    {
        Mock<IMyClassFactory> factory = new Mock<IMyClassFactory>();
        Mock<IMyClass> myClass = new Mock<IMyClass>();
        var foo = new Foo(factory.Object);
        Assert.True(foo.Method(myClass.Object));
    }
    
    [Test]
    public void ShouldCreateNewMyClassAndReturnSomeFunctionValue()
    {
        bool expected = true;
        Mock<IMyClass> myClass = new Mock<IMyClass>();
        myClass.Setup(mc => mc.SomeFunctionReturningBool()).Returns(expected);
        Mock<IMyClassFactory> factory = new Mock<IMyClassFactory>();
        factory.Setup(f => f.CreateMyClass()).Returns(myClass.Object);
    
        var foo = new Foo(factory.Object);
    
        Assert.That(foo.Method(null), Is.EqualTo(expected));
        factory.VerifyAll();
        myClass.VerifyAll();
    }
