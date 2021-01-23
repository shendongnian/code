    public static void TestOne()
    {
        Boolean result;
        Int32 i = 2;
        for (Int32 j = 0; j < 1000000000; ++j)
            result = (i < 1);
    }
    public static void TestTwo()
    {
        Boolean result;
        Int32 i = 2;
        for (Int32 j = 0; j < 1000000000; ++j)
            result = (i <= 0);
    }
