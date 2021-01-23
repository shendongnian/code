        <ListBox ItemsSource="{Binding Items}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="5">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="50"/>
                            <ColumnDefinition Width="10"/>
                            <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <Image Source="{Binding Image}"/>
                        <Grid Grid.Column="2">
                            <Grid.RowDefinitions>
                                <RowDefinition Height="*"/>
                                <RowDefinition Height="*"/>
                                <RowDefinition Height="*"/>
                            </Grid.RowDefinitions>
                            <TextBlock Text="{Binding Name}"/>
                            <TextBlock Grid.Row="1" Text="{Binding Desc}"/>
                            <TextBlock Grid.Row="2" Text="{Binding Notes}"/>
                        </Grid>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
_______________________________________________________________________
    public partial class ImageListBox : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
        public ImageListBox()
        {
            DataContext = this;
            Items = new ObservableCollection<Item>(new List<Item>
                                                         {
                                                             new Item { Image = "Images/_(1).png" , Desc = "Desc1",Name = "Name1",Notes = "Notes1"},
                                                             new Item { Image = "Images/_(2).png" , Desc = "Desc2",Name = "Name2",Notes = "Notes2"},
                                                             new Item { Image = "Images/_(3).png" , Desc = "Desc3",Name = "Name3",Notes = "Notes3"},
                                                             new Item { Image = "Images/_(4).png" , Desc = "Desc4",Name = "Name4",Notes = "Notes4"},
                                                             new Item { Image = "Images/_(5).png" , Desc = "Desc5",Name = "Name5",Notes = "Notes5"},
                                                         });
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Item
    {
        public String Image { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }
        public String Notes { get; set; }
    }
