    [ExpectedException(typeof(InvalidArgumentException))]
    [Test]
    void SomeTestMethod()
    {
        Direction testValue = (Direction)-1;
        Assert.IsFalse(Enum.IsDefined(typeof(Direction), testValue));
        SomeFunction((Direction)-1);
    }
