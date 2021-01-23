    public class Material
    {
        public string Name { get; set; }    
    }
    
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Materials = new Material[] { new Material { Name = "M1" }, new Material { Name = "M2" }, new Material { Name = "M3" } };
        }
    
        private Material[] _materials;
        public Material[] Materials
        {
            get { return _materials; }
            set { _materials = value;
                NotifyPropertyChanged("Materials");
            }
        }
    
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
            DataContext = new ViewModel();
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridtext.DataContext = (lbox.SelectedItem);
        }
    }
.
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        
        <Grid x:Name="gridtext">
            <TextBlock Text="{Binding Name}" />
        </Grid>
    
        <ListBox x:Name="lbox" 
                 Grid.Row="1"
                 ItemsSource="{Binding Materials}"
                 SelectionChanged="ListBox_SelectionChanged">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}" />
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
