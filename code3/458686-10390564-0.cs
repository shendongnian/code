    public class TestViewModel
    {
        public TestViewModel()
        {
            Items = new List<TestItemViewModel>{ 
                        new TestItemViewModel(), new TestItemViewModel() };
        }
        public ICommand HelpCommand { get; private set; }
        public IList<TestItemViewModel> Items { get; private set; }
    }
    public class TestItemViewModel
    {
        public TestItemViewModel()
        {
            // Expression Blend ActionCommand
            HelpCommand = new ActionCommand(ShowHelp);
            Header = "header";
        }
        public ICommand HelpCommand { get; private set; }
        public string Header { get; private set; }
        private void ShowHelp()
        {
            Debug.WriteLine("Help item");
        }
    }
    <Window.Resources>
        <ContextMenu x:Key="FooMenu">
            <MenuItem Header="Help" Command="{Binding HelpCommand}"/>
        </ContextMenu>
        <DataTemplate x:Key="ItemTemplate">
            <TextBlock Text="{Binding Header}"/>
        </DataTemplate>
        <DataTemplate x:Key="ContentTemplate">
            <Grid Background="#FFE5E5E5">
                <DataGrid ContextMenu="{StaticResource FooMenu}"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <Window.DataContext>
        <WpfApplication2:TestViewModel/>
    </Window.DataContext>
    <Grid>
        <TabControl 
            ItemsSource="{Binding Items}" 
            ItemTemplate="{StaticResource ItemTemplate}" 
            ContentTemplate="{StaticResource ContentTemplate}" />
    </Grid>
