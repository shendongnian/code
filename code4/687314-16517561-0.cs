    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public ObservableCollection<string> DomainComputers = new ObservableCollection<string>();
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lvInformation.ItemsSource = DomainComputers;
            
            List<string> Computers = new List<string>();
            for (int i = 1; i < 255; i++)
            {
                Computers.Add("192.168.9." + i.ToString());
            }
    
            foreach (var comp in Computers)
            {
                System.Net.NetworkInformation.Ping objping = new System.Net.NetworkInformation.Ping();
    
                objping.PingCompleted += new PingCompletedEventHandler(objping_PingCompleted);
    
                objping.SendAsync(comp, comp);
            }
    
    
        }
    
        void objping_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action( ()=> {DomainComputers.Add(e.UserState as string);}), null);
        }
    }
