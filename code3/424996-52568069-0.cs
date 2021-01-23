    public Help(IEnumerable<CommandRegistration> commands)
        : base(serviceProvider)
    {
        _commands = commands;
    }
