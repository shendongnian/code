    public static void Main()
    {
        var doWork = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                Application.Exit(); // Quick exit for demonstration only.  
            });
        _hookID = SetHook(_proc);
        Application.Run();
        UnhookWindowsHookEx(_hookID);
    }
