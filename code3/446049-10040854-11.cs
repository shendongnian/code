    [Test]
    public void ShouldUpdateEntityWhenPatternChanged()
    {
        //Arrange
        const string pattern = @"xxx";
        var entity = new MyEntity() { SomeProperty = "someValue" };    
        var userControl = new MyUserControl();
        userControl.CreateControl();
        userControl.Entity = entity;
    
        //Act    
        userControl.Pattern = pattern;
    
        //Assert
        Assert.That(entity.SomeProperty, Is.EqualTo(pattern));
    }
