XAML
    <Window x:Class="SelectedIndexHelp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:SelectedIndexHelp"
        Title="MainWindow" Height="350" Width="525"
        ContentRendered="Window_ContentRendered"
        WindowStartupLocation="CenterScreen">
    
        <Window.Resources>
            <local:SelectedIndexClass x:Key="SelectedIndexClass" />
        </Window.Resources>
        <Grid DataContext="{StaticResource SelectedIndexClass}">
            <ListBox x:Name="MyListBox" 
                     BorderThickness="1" 
                     Width="200" Height="200"
                     BorderBrush="#CE5E48" 
                     DisplayMemberPath="Name" 
                     Background="AliceBlue" 
                     SelectedIndex="{Binding MySelectedIndex, Mode=OneWayToSource}" />
            <Label Name="SelectedIndex" VerticalAlignment="Top"
                   Content="{Binding MySelectedIndex}"
                   ContentStringFormat="SelectedIndex: {0}"
                   Width="100" Height="30" Background="Lavender" />
        </Grid>
    </Window>
	
Code behind
    public partial class MainWindow : Window
    {
        public class Person
        {
            public string Name
            {
                get;
                set;
            }
            public int Age
            {
                get;
                set;
            }            
        }
        private ObservableCollection<Person> DataForListBox = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DataForListBox.Add(new Person()
            {
                Name = "Sam",
                Age = 22,
            });
            DataForListBox.Add(new Person()
            {
                Name = "Nick",
                Age = 21,
            });
            DataForListBox.Add(new Person()
            {
                Name = "Cris",
                Age = 25,
            });
            DataForListBox.Add(new Person()
            {
                Name = "Josh",
                Age = 36,
            });
            DataForListBox.Add(new Person()
            {
                Name = "Max",
                Age = 32,
            });
            DataForListBox.Add(new Person()
            {
                Name = "John",
                Age = 40,
            });
            MyListBox.ItemsSource = DataForListBox;
            MyListBox.Focus();
        }
    }
    public class SelectedIndexClass 
    {
        private int? mySelectedIndex = 0;
        public int? MySelectedIndex
        {
            get
            {
                return mySelectedIndex;
            }
            set
            {
                mySelectedIndex = value;
            }
        }
    }
	
Output
