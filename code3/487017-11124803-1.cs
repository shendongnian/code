    CommandFactory factory = new CommandFactory(args);
    if (factory.IsValid()) {
      ICommand command = factory.Create();
      command.Execute();
    }
