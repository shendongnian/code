     protected void Application_Start()
        {
            DisplayModes.Modes.Insert(0, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });
            DisplayModes.Modes.Insert(0, new DefaultDisplayMode("WindowsPhone")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }
