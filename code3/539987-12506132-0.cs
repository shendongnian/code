    void startProgress()
    {
        ThreadStart ts = new ThreadStart(Go);
        Thread t = new Thread(ts);
        t.Start();
    }
    void Go()
    {
        double val = 0;
        while (val < 100)
        {
            Thread.Sleep(50);
            Dispatcher.Invoke(new action(() =>
            {
                MyProgressBar.Value += 0.5;
                val = MyProgressBar.Value;
            }));
        }
    }
    delegate void action();
