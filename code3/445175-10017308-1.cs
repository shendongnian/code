    // Create ui elements.
    StackPanel CloseCmdStackPanel = new StackPanel();
    Button CloseCmdButton = new Button();
    CloseCmdStackPanel.Children.Add(CloseCmdButton);
    
    // Set Button's properties.
    CloseCmdButton.Content = "Close File";
    CloseCmdButton.Command = ApplicationCommands.Close;
    
    // Create the CommandBinding.
    CommandBinding CloseCommandBinding = new CommandBinding(
        ApplicationCommands.Close, CloseCommandHandler, CanExecuteHandler);
    
    // Add the CommandBinding to the root Window.
    RootWindow.CommandBindings.Add(CloseCommandBinding);
