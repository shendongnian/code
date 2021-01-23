    private static int isFirst = 1;
    public static void Foo()
    {
        if (Interlocked.Exchange(ref isFirst, 0) == 1)
        {
            //DoStuff
        }
    }
