    public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
            }
    
            public List<string> ListSting
            {
                get { return new List<string> { "one", "two", "three" }; }
            }
    
            private void Test(object sender, SelectionChangedEventArgs e)
            {
                ListBox lb = (ListBox)sender;
                System.Diagnostics.Debug.WriteLine(lb.SelectedItem.ToString());
            }
    <ListBox  SelectionChanged="Test"  ItemsSource="{Binding Path=ListSting}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding}" />
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
