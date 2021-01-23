    public MyControl(){
        InitializeComponent();
        ...
        dataGrid.CommandBindings.Add(new CommandBinding(ApplicationCommands.SelectAll, SelectAll_Executed));
    }
