    namespace BackupCiscoConfigs
    {
        /// <summary>
        /// Interaction logic for ProcessRunning.xaml
        /// </summary>
        public partial class ProcessRunning : Window, INotifyPropertyChanged
        {
            private MainWindow m_parent;
            private Configuration currentConfig;
            private DeviceInterface di;
            public event PropertyChangedEventHandler PropertyChanged;
            // This method is called by the Set accessor of each property. 
            // The CallerMemberName attribute that is applied to the optional propertyName 
            // parameter causes the property name of the caller to be substituted as an argument. 
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            private ObservableCollection<Task> _results;
            public ObservableCollection<Task> Results
            get
            {
                return _results;
            }
            set
            {
                _results= value;
                NotifyPropertyChanged("results");
            }
            public ProcessRunning(MainWindow parent)
            {
                currentConfig = Configuration.loadConfig();
                m_parent = parent;
                InitializeComponent();
            }
    
            private void btnRun_Click(object sender, RoutedEventArgs e)
            {
                List<Device> devices = currentConfig.devices;
                di = new DeviceInterface(currentConfig.tftpIP,
                    currentConfig.tftpDIR, currentConfig.cmd);
                di.RunCommands(devices);
                Results = di.results;
            }
        }
    }
