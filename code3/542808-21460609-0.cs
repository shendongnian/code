    public class AppBarClosedCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
            typeof(AppBarClosedCommand), new PropertyMetadata(null, CommandPropertyChanged));
        public static void SetCommand(DependencyObject attached, ICommand value)
        {
            attached.SetValue(CommandProperty, value);
        }
        public static ICommand GetCommand(DependencyObject attached)
        {
            return (ICommand)attached.GetValue(CommandProperty);
        }
        private static void CommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Attach click handler
            (d as AppBar).Closed += AppBar_onClose;
        }
        private static void AppBar_onClose(object sender, object e)
        {
            // Get GridView
            var appBar = (sender as AppBar);
            // Get command
            ICommand command = GetCommand(appBar);
            // Execute command
            command.Execute(e);
        }
    }
