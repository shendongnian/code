    static void MonitorProcess(string process, Action exitAction)
    {
        Task.Factory.StartNew(() =>
        {
            while (true)
            {
                if (Process.GetProcessesByName(process).Count() == 0)
                {
                    exitAction();
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        });
    }
