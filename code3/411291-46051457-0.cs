    /// must be public & static for MemberDataAttr to use
    public static TheoryData<int, bool, string> DataForTest1 = new TheoryData<int, bool, string> {
        { 1, true, "First" },
        { 2, false, "Second" },
        { 3, true, "Third" }
    };
    [Theory(DisplayName = "My First Test"), MemberData(nameof(DataForTest1))]
    public void Test1(int valA, bool valB, string valC)
    {
        Debug.WriteLine($"Running {nameof(Test1)} with values: {valA}, {valB} & {valC} ");
    }
