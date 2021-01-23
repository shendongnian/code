    public List<CommandInfo> Commands = new List<CommandInfo>();
    
    public MyClass()
    {
        Commands.Add(new CommandInfo { Name = "abc",
                                       Action = AbcAction });
    }
