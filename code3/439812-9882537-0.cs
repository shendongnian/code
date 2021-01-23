    public partial class WcfHost : Form
    {
        private ServiceHost _svcHost;
        private Uri _svcAddress = new Uri("http://localhost:9001/hello");
    
        public WcfHost()
        {
            _svcHost = new ServiceHost(typeof(HelloWorldService), _svcAddress);
    
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            _svcHost.Description.Behaviors.Add(smb);
    
            InitializeComponent();
    
            FormClosing += WcfHost_FormClosing;
        }
    
        private void WcfHost_Load(object sender, EventArgs e)
        {
            try
            {
                _svcHost.Open(TimeSpan.FromSeconds(10));
                lblStatus.Text = _svcHost.State.ToString();
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message;
            }            
        }
    
        void WcfHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            _svcHost.Close();
    
            lblStatus.Text = _svcHost.State.ToString();
        }
    }
    
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }
    
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }
