    // MySettings.cs
    public static class MySettings
    {
        public static IList RecentSearchedRepo = new ObservableCollection<object>();
    }
    // MyVm.cs
    public class MyVm : INotifyPropertyChanged
    {
        private IList recentSearch = new ObservableCollection<object>();
        public event PropertyChangedEventHandler PropertyChanged;
        public MyVm()
        {
            this.RecentSearch = MySettings.RecentSearchedRepo;
        }
        public IList RecentSearch
        {
            get { return recentSearch; }
            set 
            { 
                recentSearch = value;
                this.RaisePropertyChanged("RecentSearch");
            }
        }
        private void RaisePropertyChanged(string p)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            // Initialization as described in the question
            MySettings.RecentSearchedRepo.Add("SearchItem1");
            MySettings.RecentSearchedRepo.Add("SearchItem2");
            this.DataContext = new MyVm();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Add a new item later
            MySettings.RecentSearchedRepo.Add("NewlyAddedSearchItem");
        }
    }
    // MainWindow.xaml
    <Window x:Class="ScratchWpf.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <DockPanel>
            <Button DockPanel.Dock="Bottom" Content="Add new Search Item" Click="Button_Click_1" />
            <ListBox ItemsSource="{Binding RecentSearch}" />
        </DockPanel>
    </Window>
