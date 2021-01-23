    public static class TestClass
    {
        public const int constValue1 = 1;
        public const int constValue2 = 2;
        public const int constValue3 = 3;
    }
    enum TestEnum
    {
        testVal1, testVal2, testVal3
    }
    public int TestFunction(TestEnum testEnum)
    {
        switch (testEnum)
        {
            case TestEnum.testVal1:
                return TestClass.constValue1;
            case TestEnum.testVal2:
                return TestClass.constValue2;
            case TestEnum.testVal3:
                return TestClass.constValue3;
        }
        return 0; // all code paths have to return a value
    }
