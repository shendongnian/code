    public static readonly ICommand DummyCommand = new RoutedCommand("Dummy", typeof(Control));
        public static void Dummy(Object sender, ExecutedRoutedEventArgs e)
        {
            // Do nothing its a dummy command
        }
        public static void CanDummy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        } 
