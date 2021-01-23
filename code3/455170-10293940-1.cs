    Dictionary<string, RelayCommand> _relayCommands 
        = new Dictionary<string, RelayCommand>();
    public ICommand SomeCmd
    {
        get
        {
            RelayCommand command;
            string commandName = "SomeCmd";
            if (_relayCommands.TryGetValue(commandName, out command))
                return command;
            command = new RelayCommand(
                param => {},
                param => true);
            return _relayCommands[commandName] = command;
        }
    }
    void Dispose()
    {
        foreach (string commandName in _relayCommands.Keys)
            _relayCommands[commandName].Dispose();
        _relayCommands.Clear();
    }
