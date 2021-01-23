    [Test]
    public void MethodName_CallDatabase_ObjectDeserialized()
    {
        //Arrange
        var db = new db();
        //Act 
        var output = db.ExecuteCall();
        //Assert
        Assert.That(output, Is.EqualTo("123"));
    }
