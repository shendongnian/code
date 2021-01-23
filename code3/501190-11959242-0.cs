    private static Mutex mutex = new Mutex(true, @"Global\{my-guid-here}");
    static void Main(string[] args)
    {
        if (mutex.WaitOne(TimeSpan.Zero, true))
        {
            try
            {
                var host = HostFactory.New(x =>
                {
                    x.Service<MyService>(s =>
                    {
                        s.ConstructUsing(name => new MyService());
                        s.WhenStarted(tc =>
                        {
                            tc.Start();
                        });
                        s.WhenStopped(tc => tc.Stop());
                    });
                    x.RunAsLocalSystem();
                    x.SetDescription(STR_ServiceDescription);
                    x.SetDisplayName(STR_ServiceDisplayName);
                    x.SetServiceName(STR_ServiceName);
                });
                host.Run();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        else
        {
            // logger.Fatal("Already running MyService application detected! - Application must quit");
        }
    }
