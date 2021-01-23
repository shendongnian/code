    long InnerTime = 0;
    long OutterTime = 0;
    Stopwatch Stopw1 = new Stopwatch();
    Stopwatch Stopw2 = new Stopwatch();
    Stopw1.Start();
    int count = 1;
    int run = TestCollection.Count;
    while (count <= run) {
        Stopw2.Start();
        Medthod1();
        Stopw2.Stop();
        InnerTime = InnerTime + Stopw2.ElapsedTicks;
        Stopw2.Reset();
        count++;
    }
    Stopw1.Stop();
    OutterTime = Stopw1.ElapsedTicks;
    Stopw1.Reset();
