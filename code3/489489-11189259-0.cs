    interface ICommandSourceContext
    {
       // Since each port has own specific command
       // we can encapsulate it in the context as well
       ICommand Command { get; }
       int PortNumber { get; }
       long TimeIntervalMilliseconds { get; }
       Action<SerialDataReceivedEventArgs> Callback { get; }     
    }
    // setup and add all contexts
    IList<ICommandSourceContext> contexts = new List<ICommandSourceContext>();
    
    // ideally your main code block should looks like below (this is only pseudo code)
    foreach (var context in contexts)
    {
       // to execute it asyncronously you can use TPL Task.Start()
       // so it would not block other handlers in case of single thread
       context.Command.Execute();
       Thread.Sleep(context.TimeIntervalMilliseconds);
    }
       
