    [Test]
    public void Should_do_something_important()
    {
        // Arrange
        var dal = new DAL(new Settings { SettingOne = "whatever", SettingTwo = true });
    
        // Act
        var result = dal.DoSomethingImportant();
    
        // Assert
        Assert.That(result, Is.Not.Null);
    }
