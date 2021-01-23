    <Window x:Class="ListViewUpdate.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            DataContext="{Binding RelativeSource={RelativeSource self}}"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="auto" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <StackPanel Grid.Row="0" Orientation="Horizontal">
                <Button Content="Add10000" Click="Button_Click"/>
                <Button Content="UpdateFirst" Click="Button_Click_1"/>
                <Button Content="UpdateLast" Click="Button_Click_2"/>
                <Button Content="ReplaceFirst" Click="Button_Click_3" />
                <Button Content="UpdateAll" Click="Button_Click_4"/>
            </StackPanel>
            <ListView Grid.Row="1" ItemsSource="{Binding Path=Persons}" DisplayMemberPath="Name" />
        </Grid>
    </Window>
    namespace ListViewUpdate
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<Person> persons = new ObservableCollection<Person>();
            public MainWindow()
            {
                InitializeComponent();
            }
            public ObservableCollection<Person> Persons { get { return persons; } }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                for (UInt16 i = 0; i < 10000; i++)
                {
                    Persons.Add(new Person(Guid.NewGuid().ToString()));
                }
                System.Diagnostics.Debug.WriteLine("");
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (Persons.Count == 0) return;
                for (UInt16 i = 0; i < UInt16.MaxValue; i++)
                {
                    Persons[0].Name = Guid.NewGuid().ToString();
                }
            }
    
            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                if (Persons.Count == 0) return;
                int last = Persons.Count - 1;
                for (UInt16 i = 0; i < UInt16.MaxValue; i++)
                {
                    Persons[last].Name = Guid.NewGuid().ToString();
                }
            }
    
            private void Button_Click_3(object sender, RoutedEventArgs e)
            {
                if (Persons.Count == 0) return;
                for (UInt16 i = 0; i < UInt16.MaxValue; i++)
                {
                    Persons[0] = new Person(Guid.NewGuid().ToString());
                }
            }
    
            private void Button_Click_4(object sender, RoutedEventArgs e)
            {
                foreach (Person p in Persons) p.Name = Guid.NewGuid().ToString();
            }
        }
        public class Person: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            private string name;
            public string Name 
            {
                get { return name; }
                set
                {
                    if (name == value) return;
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
            public Person(string name) { Name = name; }
        }
    }
