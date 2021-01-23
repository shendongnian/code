    namespace BackupCiscoConfigs
    {
        /// <summary>
        /// Interaction logic for ProcessRunning.xaml
        /// </summary>
        public partial class ProcessRunning : Window
        {
            private MainWindow m_parent;
            private Configuration currentConfig;
            public DeviceInterface di;
    
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
            }
        }
    }
