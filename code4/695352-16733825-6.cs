    [Theory, AutoData]
    public void TestSomething(
        [Frozen(As = typeof(IMyInterface))]FakeMyInterface dummy,
        TypesWithoutPublicCtrs sut)
    {
        // use sut here, and ignore dummy
    }
