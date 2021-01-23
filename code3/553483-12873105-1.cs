    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;           
        }
        public IEnumerable<DummyClient> Clients
        {
            get
            {
                for (int i = 0; i < 10; i++)
                {
                    var info = new Info();
                    info.ip = "192.168.1.100";
                    info.pc = "Duncan";
                    info.status = "idle";
                    info.cid = 1;
                    yield return new DummyClient(info);
                }
            }
        }
    }
    public class DummyClient
    {
        public DummyClient(Info info)
        {
            Info = info;
        }
        public string Ip { get { return Info.ip; } }
        public string Computer { get { return Info.pc; } }
        public string Status { get { return Info.status; } }
        public int Id { get { return Info.cid; } }
        public Info Info
        {
            get;
            private set;
        }
    }
    public struct Info
    {
        public int cid;
        public string pc;
        public string ip;
        public string status;
    }
