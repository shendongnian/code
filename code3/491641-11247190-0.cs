    public static readonly DependencyProperty ActiveComputersProperty =
        DependencyProperty.Register(
            "ActiveComputers",
             typeof(ObservableCollection<ComputerListItem>),
             typeof(MainWindow),
             new PropertyMetadata(new ObservableCollection<ComputerListItem>()))
