    public static class AppCommands
    {
        private static RoutedUICommand exitCommand = new RoutedUICommand("Exit","Exit", typeof(AppCommands));
        public static RoutedCommand ExitCommand
        {
            get { return exitCommand; }
        }
        static AppCommands()
        {
            CommandBinding exitBinding = new CommandBinding(exitCommand);
            CommandManager.RegisterClassCommandBinding(typeof(AppCommands), exitBinding);
        }
    }
