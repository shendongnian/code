    enum TestEnum
    {
        Test1,
        Test2
    }
    TestEnum t = TestEnum.Test1;
    ((int)t).GetHashCode(); // no boxing
    t.GetHashCode(); // boxing
