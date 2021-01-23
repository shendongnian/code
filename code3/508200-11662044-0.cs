        <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition Height="50"/>
        </Grid.RowDefinitions>
        <ComboBox Height="23" ItemsSource="{Binding Cars}" DisplayMemberPath="Name" HorizontalAlignment="Left" Margin="244,10,0,0" Name="comboBox1" VerticalAlignment="Top" Width="120"/>
        <ComboBox Height="23" Grid.Row="1" ItemsSource="{Binding SelectedItem.Series, ElementName=comboBox1}" HorizontalAlignment="Left" Margin="244,10,0,0" Name="comboBox2" VerticalAlignment="Top" Width="120"/>
    </Grid>
        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cars = new ObservableCollection<Car>();
            Cars.Add(new Car() { Name = "Peugeut", Series = new ObservableCollection<string>() { "106", "206", "306" } });
            Cars.Add(new Car() { Name = "Ford", Series = new ObservableCollection<string>() { "406", "506", "606" } });
            Cars.Add(new Car() { Name = "BMW", Series = new ObservableCollection<string>() { "706", "806", "906" } });
            DataContext = this;
          
        }
        public ObservableCollection<Car> Cars { get; set; }
    }
    public class Car
    {
        public string Name { get; set; }
        public ObservableCollection<string> Series { get; set; }
    }
