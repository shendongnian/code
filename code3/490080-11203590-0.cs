    public void Start1()
    {
        for (int i = 0; i < 1000; i++)
        {
            t1.Invoke(() => displaytext("Working.........", i));
            Thread.Sleep(100);
        }
    }
