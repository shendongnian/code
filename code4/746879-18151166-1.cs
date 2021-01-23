    private static bool isFirst = true;
    private static object key = new object();
    public static void Foo()
    {
        bool amFirst;
        lock (key)
        {
            amFirst = isFirst;
            isFirst = false;
        }
        if (amFirst)
        {
            //DoStuff
        }
    }
