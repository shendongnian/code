    int nCores = 4;
    for (int i = 0; i < nCores;i++ )
    {
        var t = new Thread(() =>
                            {
                                while (true)
                                {
                                }
                            });
        t.Priority = ThreadPriority.Highest;
        t.Start();
    }
