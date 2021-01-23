    object obj = new object();
    void thMethod()
    {
        while (_i < 100)
        {
            lock (obj)
            {
                Console.WriteLine(_i);
                _i++;
            }
            Thread.Sleep((new Random()).Next(1, 500));
        }
    }
