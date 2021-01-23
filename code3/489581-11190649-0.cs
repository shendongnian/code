    //  logger declaration (I use NLog)
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();
    delegate void WhatTodo();
    static void TrySeveralTimes(WhatTodo Task, int Retries, int RetryDelay)
    {
        int retries = 0;
        while (true)
        {
            try
            {
                Task();
                break;
            }
            catch (Exception ex)
            {
                retries++;
                Log.Info<string, int>("Problem doing it {0}, try {1}", ex.Message, retries);
                if (retries > Retries)
                {
                    Log.Info("Giving up...");
                    throw;
                }
                Thread.Sleep(RetryDelay);
            }
        }
    }
