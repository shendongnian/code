    [Fact]
    public void CreateReturnsInstanceWithCorrectParam1()
    {
        var sut = new FooFactory();
        var expected = new object();
        var actual = sut.Create(expected, new object());
        var concrete = Assert.IsAssignableFrom<Foo>(actual);
        Assert.Equal(expected, concrete.Object1);
    }
