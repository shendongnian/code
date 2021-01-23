                Config config = new Config();
                if (Debugger.IsAttached)
                {
                    config = new Config()
                    {
                        Interval = Dev.Default.Interval,
                        Username = Dev.Default.Username,
                        Password = Dev.Default.Password,
                        Directory = Dev.Default.Directory
                    };
                }
                else
                {
                    config = new Config()
                    {
                        Interval = Settings.Default.Interval,
                        Username = Settings.Default.Username,
                        Password = Settings.Default.Password,
                        Directory = Settings.Default.Directory
                    };
                }
