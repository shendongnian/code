    public void SendCommand(Command command)
    {
        Invoke(command as dynamic);
    }
    private void Invoke<T>(T command) where T : Command
    {
        var handler = container.Resolve<IHandleCommand<T>>();
        handler.Handle(command);
    }
