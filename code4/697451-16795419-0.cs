    <Window x:Class="ListViewGetHashCode.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Button Grid.Row="0" Click="Button_Click" Content="Button"/>
            <ListBox Grid.Row="1" x:Name="lbHash" ItemsSource="{Binding}" DisplayMemberPath="ID"/> 
        </Grid>
    </Window>
    
    using System.ComponentModel;
    
    namespace ListViewGetHashCode
    {
        public partial class MainWindow : Window
        {
            List<ListItem> li = new List<ListItem>();
            public MainWindow()
            {
                this.DataContext = this;
                for (Int32 i = 0; i < 100000; i++) li.Add(new ListItem(i));
                
                InitializeComponent();
                lbHash.ItemsSource = li;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Int32 counter = 0;
                foreach (ListItem l in li)
                {
                    l.ID = -l.ID;
                    counter++;
                    if (counter > 100) break;
                }
            }
        }
        public class ListItem : Object, INotifyPropertyChanged
        {
            private Int32 id;
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            
            public Int32 ID 
            {
                get { return id; }
                set
                {
                    if (id == value) return;
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
            public override bool Equals(object obj)
            {
                if (obj is ListItem)
                {
                    ListItem comp = (ListItem)obj;
                    return (comp.ID == this.ID);
                }
                else return false;
            }
            public override int GetHashCode()
            {
                System.Diagnostics.Debug.WriteLine("GetHashCode " + ID.ToString());
                return ID;
            }
            public ListItem(Int32 ID) { id = ID; }
        }
    }
