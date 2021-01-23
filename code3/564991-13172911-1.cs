    public void Invoke(Contracts.Commands.Command command)
    {
        var handlerType = types[command.GetType()];
        dynamic handler = kernel.Get(handlerType);
        dynamic cmd = command;
        handler.Execute(cmd);
    }
