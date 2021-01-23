     public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
            }
    
            public List<string> ListString
            {
                get { return new List<string> { "one", "two", "three" }; }
            }
            public ListList ListList1 
            {
                get { return new ListList("name", new List<string> { "one", "two", "three" }); }
            }
    
            private void Test(object sender, SelectionChangedEventArgs e)
            {
                ListBox lb = (ListBox)sender;
                System.Diagnostics.Debug.WriteLine(lb.SelectedItem.ToString());
            }
    
            public class ListList
            {
                public string Name { get;  set; }
                public List<string> Values { get;  set; }
                public ListList(string name, List<string> values) { Name = name; Values = values; }
            }
    <ListBox ItemsSource="{Binding Path=ListList}">
            <ListBox  SelectionChanged="Test"  ItemsSource="{Binding Path=Values}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding}" />
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </ListBox>
