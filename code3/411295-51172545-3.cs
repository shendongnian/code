    [Theory]
    [InlineData(1, 2)]
    [InlineData(-4, -6)]
    [InlineData(2, 4)]
    public void FooTest(int value1, int value2)
    {
        Assert.True(value1 + value2 < 7)
    }
