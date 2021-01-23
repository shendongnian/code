    [Theory]
    [MemberData(nameof(BazTestData))]
    public void BazTest(int value1, int value2)
    {
        Assert.True(value1 + value2 < 7)
    }
    public static IEnumerable<object[]> BazTestData => new List<object[]>
        {
            new object[] { 1, 2 },
            new object[] { -4, -6 },
            new object[] { 2, 4 },
        };
