    public partial class MainWindow : Window
    {
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
    }
    public static class RadDockingCommands
    {
        private static RoutedUICommand closeAllPanesButThisCommand;
        
        // etc...
    }
