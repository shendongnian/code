    [TestMethod]
    public void The_Bar_Is_Required()
    {
        // arrange
        var foo = new Foo();
        var results = new List<ValidationResult>();
        var context = new ValidationContext(foo, null, null);
        // act
        var actual = Validator.TryValidateObject(foo, context, results);
        // assert
        Assert.IsFalse(actual);
    }
