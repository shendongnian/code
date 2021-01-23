        HostFactory.New(x =>
                    {
                        x.SetDisplayName("Your service");
                        x.SetServiceName("yourservice");
                        x.Service<MyService>(c =>
                        {
                            c.SetServiceName("My service");
                            c.ConstructUsing(name => container.Resolve<MyService>());
                            c.WhenStarted(s => s.Start());
                            c.WhenStopped(s => s.Stop());
                        });
                    })
                        .Run();
