    public partial class MainWindow : Window
    {
        private ObservableCollection<Device> _unsecuredDevices = new ObservableCollection<Device>();
        private ObservableCollection<Device> _securedDevices = new ObservableCollection<Device>();
        public MainWindow()
        {
            AddDevice = new RelayCommand(o => SecuredDevices.Add(o as Device), o => o != null);
            InitializeComponent();
            UnsecuredDevices.Add(new Device { Name = "Jonathan Mac", MacAddress = "00:1A:8C:B9:CC" });
            UnsecuredDevices.Add(new Device { Name = "Jonathan Mobile", MacAddress = "00:1A:8C:B9:CC" });
            UnsecuredDevices.Add(new Device { Name = "Samsung S3", MacAddress = "00:1A:8C:B9:CC" });
            UnsecuredDevices.Add(new Device { Name = "BlackBerry BB102", MacAddress = "00:1A:8C:B9:CC" });
        }
        public ICommand AddDevice { get; set; }
        public ObservableCollection<Device> UnsecuredDevices
        {
            get { return _unsecuredDevices; }
            set { _unsecuredDevices = value; }
        }
        public ObservableCollection<Device> SecuredDevices
        {
            get { return _securedDevices; }
            set { _securedDevices = value; }
        }
    }
    public class Device 
    {
        public string Name { get; set; }
        public string MacAddress { get; set; }
    }
