    public TResult Execute<TResult>(ICommand<TResult> command)
    {
        Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var handler = _container.GetInstance(commandHandlerType);
        handler.Handle(command);
        return command.Result;
    }
