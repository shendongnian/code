    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="CustomerTemplate" DataType="{x:Type ViewModel:Customer}">
                <ContentControl>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseDoubleClick">
                            <i:InvokeCommandAction Command="{Binding DoubleClickCommand}" />
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <TextBlock Text="{Binding Name}"/>
                </ContentControl>
            </DataTemplate>
        </Grid.Resources>
        <ListBox ItemsSource="{Binding Customers}" ItemTemplate="{StaticResource CustomerTemplate}" />
    </Grid>
    public class Customer : ViewModelBase
    {
        public Customer()
        {
            DoubleClickCommand = new RelayCommand(DoubleClick);    
        }
        private void DoubleClick()
        {
            Debug.WriteLine("double click");
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }
        public ICommand DoubleClickCommand { get; private set; }
    }
