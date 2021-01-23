    [Flags]
    public enum TestEnum
    {
        One = 1,
        Two = 2,
        Three = 3
    }
    TestEnum test = TestEnum.One | TestEnum.Three;
    var result = test.GetFlagValues();
