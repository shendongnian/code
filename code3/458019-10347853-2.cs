    static int test1()
    {
        int result = 0;
        int i;
        for (i = 0; i < 10; ++i)
            ++result;
        for (i = 0; i < 10; ++i)
            ++result;
        return result;
    }
    static int test2()
    {
        int result = 0;
        for (int i = 0; i < 10; ++i)
            ++result;
        for (int i = 0; i < 10; ++i)
            ++result;
        return result;
    }
