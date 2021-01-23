    //viewModel.cs
    public ObservableCollection<ComputerRecord> GridInventory {get; private set;}
    //view.xaml
    <DataGrid ... ItemsSource="{Binding GridInventory}" .../>
    
