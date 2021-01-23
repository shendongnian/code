    <Window x:Class="ListViewGetHashCode.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <StackPanel Grid.Row="0" Orientation="Horizontal">
                <Button Click="Button_Click" Content="Button"/>
                <Button Click="Button_Click2" Content="Add"/>
                <Button Grid.Row="0" Click="Button_Click_Save" Content="Save"/>
            </StackPanel>
            <ListBox Grid.Row="1" ItemsSource="{Binding BindingList}" DisplayMemberPath="ID" SelectedItem="{Binding Selected}" VirtualizingStackPanel.VirtualizationMode="Standard"/>
            <!--<ListBox Grid.Row="1" x:Name="lbHash" ItemsSource="{Binding}" DisplayMemberPath="ID"/>--> 
        </Grid>
    </Window>
    
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    
    namespace ListViewGetHashCode
    {
        public partial class MainWindow : Window
        {
            ObservableCollection<ListItem> li = new ObservableCollection<ListItem>();
            private Int32 saveId = 100;
            private Int32 tempId = -1;
            public MainWindow()
            {
                this.DataContext = this;
                for (Int32 i = 1; i < saveId; i++) li.Add(new ListItem(i));
                
                InitializeComponent();
    
            }
            public ObservableCollection<ListItem> BindingList { get { return li; } }
            public ListItem Selected { get; set; }
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
            private void Button_Click2(object sender, RoutedEventArgs e)
            {          
                //li.Add(new ListItem(0)); // this is where it breaks as items were not unique
                li.Add(new ListItem(tempId));
                tempId--;
            }   
            private void Button_Click_Save(object sender, RoutedEventArgs e)
            {
                if (Selected != null && Selected.ID <= 0)
                {
                    Selected.ID = saveId;
                    saveId++;
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
                get 
                { 
                    return (id < 0) ? 0 : id;
                    //if you want users to see 0 and not the temp id 
                    //internally much use id
                    //return id;
                }
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
                    return (comp.id == this.id);
                }
                else return false;
            }
            public bool Equals(ListItem comp)
            {
                return (comp.id == this.id);
            }
            public override int GetHashCode()
            {
                System.Diagnostics.Debug.WriteLine("GetHashCode " + id.ToString());
                return id;
                //can even return 0 as the hash for negative but it will only slow 
                //things downs
                //if (id > 0) return id;
                //else return 0;
            }
            public ListItem(Int32 ID) { id = ID; }
        }
    }
