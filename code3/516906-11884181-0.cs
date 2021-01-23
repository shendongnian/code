    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons ?? (_persons = new ObservableCollection<Person>()); }
            set { _persons = value; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var split = txtBox.Text.Split(' ');
            try
            {
                Persons.Add(new Person() { FirstName = split[0], LastName = split[1], Age = Int32.Parse(split[2]) });
            }
            catch (IndexOutOfRangeException)
            {
            }
            catch (FormatException)
            {
            }
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    <Window x:Class="ItemsControlTest.TestWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="TestWindow" Height="300" Width="300">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="auto"/>
        </Grid.ColumnDefinitions>
        <TextBox Name="txtBox" Text="Firstname lastname 10"/>
        <Button Grid.Column="1" Click="Button_Click" Content="click me"/>
        <DataGrid Grid.Row="1" Grid.ColumnSpan="2" ItemsSource="{Binding Path=Persons}">
            
        </DataGrid>
    </Grid>
