    public enum Action
    {
        ShowHelp,
        ShowVersion,
        PromptConfig,
        LaunchApplication
    }
    public static void Main (string[] args)
    {
        var action = Action.LaunchApplication;
        var options = new OptionSet() {
            {
                "h", "Show help",
                v => action = Action.ShowHelp
            },
            {
                "config", "Reconfigure the launcher with different settings",
                v => action = Action.PromptConfig
            },
            {
                "v", "Show current version",
                v => action = Action.ShowVersion
            }, 
            {
                "launch",
                v => action = Action.LaunchApplication
            }
        }
    
        try 
        {
            // parse arguments
            var extra = options.Parse(args);
        
            // act
            switch (action)
            {
                // ... cases here to do the actual work ...
            }
        }
        catch (OptionException e) 
        {
            Console.WriteLine("MyApp: {0}", e.Message);
            Console.WriteLine("Try `MyApp --help' for more information");
        }
    }
    
