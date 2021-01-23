    public MainWindow()
    {
        InitializeComponent();
    
        CommandManager.RegisterClassCommandBinding(
        typeof( RadPaneGroup ),
        new CommandBinding(
            RadDockingCommands.CloseAllPanesButThisCommand,
            RadDockingCommands.OnCloseAllPanesButThis,
            RadDockingCommands.OnCloseAllPanesButThisCanExecute ) );
    }
