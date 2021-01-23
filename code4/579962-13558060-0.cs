    <Window x:Class="WpfApplication6.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525" Name="UI">
        <Grid>
            <ComboBox ItemsSource="{Binding ElementName=UI,Path=YourCollection}" SelectedItem="{Binding ElementName=UI,Path=SelectedItem}" Height="23" HorizontalAlignment="Left" Margin="65,61,0,0" Name="comboBox1" VerticalAlignment="Top" Width="120" />
            <ComboBox ItemsSource="{Binding ElementName=UI, Path=FilteredCollection}" Height="23" HorizontalAlignment="Left" Margin="223,61,0,0" Name="comboBox2" VerticalAlignment="Top" Width="120" />
        </Grid>
    </Window>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _selectedItem;
        private ObservableCollection<string> _yourCollection = new ObservableCollection<string>();
    
        public MainWindow()
        {
            InitializeComponent();
            YourCollection.Add("Apple");
            YourCollection.Add("Banana");
            YourCollection.Add("Pear");
            YourCollection.Add("Orange");
            NotifyPropertyChanged("FilteredCollection"); 
        }
    
        // Collection Fro ComboBox A
        public ObservableCollection<string> YourCollection
        {
            get { return _yourCollection; }
            set { _yourCollection = value; }
        }
      
        // ComboBox A selected Item
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
    
                // Notify the the filter collection has changed
                NotifyPropertyChanged("FilteredCollection"); 
            }
        }
        
        // Collection to show in ComboBox B
        public List<string> FilteredCollection
        {
            // Remove the selected Item
            get { return _yourCollection.Where(s => !s.Equals(_selectedItem)).ToList(); }
        }
    
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
