    public partial class MainWindow : Window
    {
        private ObservableCollection<ConnectionItem> _connectionitems = new ObservableCollection<ConnectionItem>();
    
        public MainWindow()
        {
            InitializeComponent();
            ConnectionItems.Add(new ConnectionItem { Name = "Item1", Ping = "150ms" });
            ConnectionItems.Add(new ConnectionItem { Name = "Item2", Ping = "122ms" });
        }
    
        public ObservableCollection<ConnectionItem> ConnectionItems
        {
            get { return _connectionitems; }
            set { _connectionitems = value; }
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // to change a value jus find the item you want in the list and change it
            // because your ConnectionItem class implements INotifyPropertyChanged
            // ite will automaticly update the dataGrid
    
            // Example
            ConnectionItems[0].Ping = "new ping :)";
        }
    }
    
    public class ConnectionItem : INotifyPropertyChanged
    {
        private string _name;
        private string _ping;
    
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
    
        public string Ping
        {
            get { return _ping; }
            set { _ping = value; NotifyPropertyChanged("Ping"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="property">The info.</param>
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
