    for (int i = 0; i < 8; ++i)
    {
        var ar = new int[500000000];
        GC.Collect();
        test1(ar);
        //ar = new int[500000000]; // Uncomment this line.
        test2(ar);
    }
