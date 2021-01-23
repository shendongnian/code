    [Theory]
    [InlineData("Foo")]
    [InlineData(9)]
    [InlineData(true)]
    public void Should_be_assigned_different_values(object value)
    {
        Assert.NotNull(value);
    }
