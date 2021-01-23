    public static void OutTester(out int a)
    {
        a = 1;
    }
    public static void OutOutTester(out int a, out int b)
    {
        OutTester(out a);
        b = 1;
    }
