    [Test]
    public void ShouldUpdateEntityWhenPatternChanged()
    {
        //Arrange
        var entity = new MyEntity() { SomeProperty = "someValue" };    
        var userControl = new MyUserControl(entity);
        const string pattern = @"xxx";
    
        //Act    
        userControl.Pattern = pattern;
    
        //Assert
        Assert.That(entity.SomeProperty, Is.EqualTo(pattern));
    }
